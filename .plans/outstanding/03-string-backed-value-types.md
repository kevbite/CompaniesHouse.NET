# 03 — String-backed value types (replace all enums)

**Status:** outstanding
**Depends on:** `01-core-client-architecture` (for STJ options)
**Blocks:** every model with an "enum" field; pairs with `04` (generator)

## Goal

Replace every C# `enum` used on the API contract with a **string-backed
`readonly record struct`** that preserves the raw wire value and never throws on
an unrecognised value. This kills the single largest category of historical bugs
in this library.

## Why

Companies House claim API versioning but do not honour it, so new string values
appear in responses without warning. With plain enums + `StringEnumConverter`,
each new value is a `JsonException`/`ArgumentException` at deserialization for
every consumer who hasn't upgraded. See the design blog:
<https://kevsoft.net/2026/06/28/enums-in-api-contracts.html> and the trail of
issues: #168, #185, #186, #197, #198, #200, #201, #209, #218.

## The pattern

For each API enum group (e.g. `CompanyStatus`, `CompanyType`, `OfficerRole`):

```csharp
[JsonConverter(typeof(CompanyStatusJsonConverter))]
public readonly record struct CompanyStatus(string Value)
{
    // Known values (generated — see plan 04)
    public static CompanyStatus Active => new("active");
    public static CompanyStatus Dissolved => new("dissolved");
    // ...

    public bool IsKnown => KnownValues.Contains(Value);

    // Optional: human-readable description from api-enumerations
    public string? Description => Descriptions.GetValueOrDefault(Value);

    public override string ToString() => Value;
}
```

Converter (trivial — just reads/writes the string, no lookup, no throw):

```csharp
public sealed class CompanyStatusJsonConverter : JsonConverter<CompanyStatus>
{
    public override CompanyStatus Read(ref Utf8JsonReader reader, Type t, JsonSerializerOptions o)
        => new(reader.GetString()!);
    public override void Write(Utf8JsonWriter writer, CompanyStatus value, JsonSerializerOptions o)
        => writer.WriteStringValue(value.Value);
}
```

### Requirements
- **Never throws** on unknown values — the raw string is retained (issue #156
  asked for raw-value access; this delivers it for free).
- **Equatable / usable in `switch`** via `== Known.X` patterns; value-equality
  from `record struct`.
- **`IsKnown`** to branch on recognised vs unrecognised.
- **Prefix helpers** where CH uses structured values (the blog's
  `IsProcessing`/`ProcessingStep` idea) — e.g. filing categories/subcategories.
  Provide these where the enumeration is naturally hierarchical.
- **Null handling** — the old `OptionalStringEnumConverter` mapped null to a
  default. Decide: default to `default(struct)` (empty `Value`) vs a `None`
  static. (Lean: `Value == ""`/`default` represents absent; expose `HasValue`.)
- Optional **`Description`** property backed by the api-enumerations
  descriptions, so consumers get the friendly text (partially covers issue #205
  "SIC codes?" and the various `*_descriptions.yml`).

## Scope

- Define the shared building blocks (base converter helpers, common members,
  analyzers/format) that the generator (plan `04`) will emit against.
- Hand-author **one or two** value types first (e.g. `CompanyStatus`) to prove
  the pattern and the converter, its tests, and STJ registration — then let the
  generator take over producing the rest.
- Registration: value-type converters are applied via `[JsonConverter]` on the
  type, so no central registration is strictly needed, but confirm they compose
  with the shared `JsonSerializerOptions` (plan `01`).

## Tasks

- [ ] Implement the reference value type + converter by hand (`CompanyStatus`).
- [ ] Unit tests: known value, unknown value (no throw, raw preserved),
      round-trip, equality, `IsKnown`, null/empty.
- [ ] Decide + document null/absent semantics and prefix-helper conventions.
- [ ] Freeze the shape the generator must emit (feed into plan `04`).
- [ ] Migrate models to use value types as endpoints are built.

## Design decisions

- **`readonly record struct` wrapping a string** — preserves raw value, value
  equality, cheap, immutable. Chosen over "enum + Unknown fallback" (loses the
  raw value) per the blog.
- **Converter does no validation** — unknown values are first-class, not errors.

## Open questions

- Provide implicit `string` conversions? (Lean: explicit `Value`/`ToString`
  only, to avoid accidental stringly-typed misuse; revisit.)
- Ship `Description` in v-next or defer? (Lean: ship it — it's cheap once the
  generator reads the YAML descriptions and answers real requests.)

## Acceptance criteria

- Deserializing an unknown status string succeeds and round-trips byte-for-byte.
- Known values compare equal to the static members.
- No plain enum remains on any wire-facing model once endpoints are migrated.

## References

- Blog: <https://kevsoft.net/2026/06/28/enums-in-api-contracts.html>
- Issues #156, #168, #185, #186, #197, #198, #200, #201, #209, #218.

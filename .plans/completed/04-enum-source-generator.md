# 04 — Enum source generator

**Status:** complete
**Depends on:** `03-string-backed-value-types` (target shape), `05-submodule`
(input data)
**Blocks:** full model coverage

## Goal

Build a Roslyn **incremental source generator** that emits the string-backed
value types (plan `03`) from the Companies House `api-enumerations` YAML plus our
own local "extra" lists — so new enum values are picked up by rebuilding and
releasing, never by hand-coding.

## Why

Hand-maintaining enum members is exactly the treadmill that produced issues
#168, #185, #186, #197, #198, #200, #201, #209, #218. Generating from the
authoritative YAML means a version bump (not a code change) absorbs new values,
and unknown values never break consumers anyway (plan `03`).

## Input data

The `api-enumerations` repo (submodule — plan `05`) contains YAML files whose
top-level keys are enum groups and whose entries are `'wire-value': "Friendly
Description"`. Example (`constants.yml`):

```yaml
company_status:
    'active' : "Active"
    'dissolved' : "Dissolved"
company_type:
    'ltd' : "Private limited company"
    'plc' : "Public limited company"
```

Relevant files include (non-exhaustive — enumerate at implementation time):
`constants.yml` (company_status, company_type, company_summary, jurisdiction,
identification_type, ...), `filing_history_descriptions.yml`,
`mortgage_descriptions.yml`, `psc_descriptions.yml`,
`disqualified_officer_descriptions.yml`, `exemption_descriptions.yml`,
`officer_filing.yml`, `psc_filing.yml`, etc.

## Design

### Generator project
- New project `src/CompaniesHouse.SourceGenerator`, targeting
  **`netstandard2.0`** (Roslyn requirement), referencing
  `Microsoft.CodeAnalysis.CSharp` (analyzer/generator packaging — `PrivateAssets`
  so it isn't a runtime dependency of consumers).
- Ship the generator **inside the `CompaniesHouse` package** (analyzer asset),
  or wired as a project-reference `OutputItemType="Analyzer"` — decide packaging
  (lean: bundle as analyzer in the main package so no extra dependency for
  consumers).

### Inputs → generator
- Feed the YAML files as **`AdditionalFiles`** (from the submodule path + our
  local extras folder) so the generator reads them via
  `context.AdditionalTextsProvider` (incremental, cache-friendly). Avoid doing
  network I/O in the generator — the submodule provides the files at build time.
- A small **mapping/config** (attribute, or a `enum-map.json`) declares which
  YAML key maps to which C# type name + namespace, plus:
  - PascalCase member-name conversion from wire values
    (`private-unlimited` → `PrivateUnlimited`), with a collision/override table
    for awkward values (empty string, values differing only by punctuation, or
    C# keyword clashes).
  - Which groups get prefix helpers (plan `03`).
  - Which groups expose `Description`.

### Output
- For each configured group, emit the `readonly record struct`, its `[JsonConverter]`,
  the static known-value members, `KnownValues`, optional `Descriptions`
  dictionary, `IsKnown`, and any configured prefix helpers — matching the frozen
  shape from plan `03`.
- Emit into the `CompaniesHouse.Response` (or a dedicated `CompaniesHouse.Enums`)
  namespace.

### Extensibility (our own extra lists)
- Support a repo-local `enumerations/extra/*.yml` (same format) merged on top of
  the submodule data, so we can add values CH hasn't published yet or define
  library-only groups. Merge order: submodule first, extras override/append.

## Tasks

- [ ] Scaffold the generator project (netstandard2.0 + CodeAnalysis).
- [ ] YAML parsing (a lightweight parser or `YamlDotNet` — note: generator deps
      must be bundled into the analyzer; prefer a minimal parser to avoid load
      issues).
- [ ] Wire YAML files as `AdditionalFiles` (submodule + extras).
- [ ] Implement wire-value → PascalCase with an override table.
- [ ] Emit value types matching plan `03`'s shape.
- [ ] Snapshot/verify tests over the generated output (plan `10`).
- [ ] Package the generator as an analyzer in the `CompaniesHouse` package.

## Design decisions

- **Incremental generator + `AdditionalFiles`** — no network at build, cacheable,
  fast.
- **Local extras override submodule** — lets us react even faster than CH.
- **Bundle in the main package** — zero extra dependency for consumers.

## Open questions

- YAML parser choice inside the generator (bundling `YamlDotNet` into an
  analyzer can be fiddly). (Lean: minimal hand-rolled parser for the simple
  `key: {'v':"desc"}` shape; revisit if files use richer YAML.)
- Do we generate at consumer build-time, or generate once in *this* repo and
  commit the output? (Lean: generate in *this* repo's build so the shipped
  package contains concrete types; the generator need not run in consumers.
  Confirm — this affects packaging: generator could be a build-time-only tool
  rather than a shipped analyzer.)

## Acceptance criteria

- Adding a value to a YAML file and rebuilding produces a new static member with
  no hand-editing.
- Generated types compile clean under `TreatWarningsAsErrors`.
- Unknown values (not in YAML) still deserialize fine at runtime (plan `03`).

## References

- api-enumerations: <https://github.com/companieshouse/api-enumerations>
- Blog: <https://kevsoft.net/2026/06/28/enums-in-api-contracts.html>
- Recurring enum issues: #168, #185, #186, #197, #198, #200, #201, #209, #218.

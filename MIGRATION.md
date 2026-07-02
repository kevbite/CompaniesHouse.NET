# Migration guide: v-next (breaking changes)

This is a new major version of `CompaniesHouse.NET`. It is a deliberate,
breaking rewrite - it does not attempt to be a drop-in replacement. This guide
covers every breaking change with a before/after snippet so you can migrate
call sites methodically.

## Target frameworks

**Before:** `net45`, `netstandard2.0` (or similar).
**After:** `net8.0`, `net9.0`, `net10.0` only.

If you're on .NET Framework or an older .NET/`netstandard` target, you'll need
to stay on the previous major version, or upgrade your app to a supported TFM.

## JSON: `Newtonsoft.Json` → `System.Text.Json`

The client no longer depends on `Newtonsoft.Json` at all (see issue #188). All
(de)serialization uses `System.Text.Json`.

This mostly only matters if you had custom `JsonConverter`s or relied on
`Newtonsoft`-specific behaviour (e.g. `JObject`/`JToken` on the response
models, or `[JsonProperty]` attributes):

```diff
- using Newtonsoft.Json;
- var json = JsonConvert.SerializeObject(profile);
+ using System.Text.Json;
+ using CompaniesHouse;
+ var json = JsonSerializer.Serialize(profile, CompaniesHouseJsonSerializerOptions.Default);
```

If you were deserializing raw API responses yourself, use
`CompaniesHouseJsonSerializerOptions.Default` so enum value types and casing
are handled consistently with the client.

## Enums → string-backed value types

This is the biggest behavioural change. Every API "enum" (company status,
officer role, charge type, jurisdiction, ...) used to be a plain C# `enum`.
It's now a **string-backed, readonly `record struct`** that never throws for
an unrecognised value.

**Before:**

```csharp
public enum CompanyStatus
{
    Active,
    Dissolved,
    // ... a fixed, hand-maintained list
}

switch (profile.CompanyStatus)
{
    case CompanyStatus.Active:
        Console.WriteLine("is active");
        break;
    case CompanyStatus.Dissolved:
        Console.WriteLine("is dissolved");
        break;
    default:
        // Companies House adding a new status value could throw a
        // JsonSerializationException during deserialization, or silently
        // map to an unrelated member, depending on the old converter.
        break;
}
```

**After:**

```csharp
var description = profile.CompanyStatus switch
{
    var s when s == CompanyStatus.Active => "is active",
    var s when s == CompanyStatus.Dissolved => "is dissolved",
    var s when s.IsKnown => s.Description, // any other value this library recognises
    var s => $"unrecognised status: {s.Value}", // never throws, even for brand-new values
};
```

Key API differences to update at each call site:

- Replace `EnumType.Member` usages with the equivalent static member on the
  value type (e.g. `CompanyStatus.Active` still works, but it's a value not an
  `enum` member - `==`/`!=` work as expected via `record struct` equality).
- Replace `switch` statements on the type itself with pattern matching against
  equality (`s == CompanyStatus.Active`), since the value type isn't a closed
  set of cases.
- Anywhere you called `.ToString()` expecting the C# member name (e.g.
  `"Active"`), note that `ToString()` now returns the **raw wire value**
  (e.g. `"active"`); use `.Description` for a friendly name.
- Anywhere you relied on `Enum.Parse`/`Enum.TryParse`, construct the value type
  directly from the wire string instead: `new CompanyStatus("active")`.

See the [README's enum section](README.md#enumvalue-type-handling) and the
[design rationale](https://kevsoft.net/2026/06/28/enums-in-api-contracts.html)
for more detail.

## `CompaniesHouseClientResponse<T>` shape change

**Before:** the response wrapper exposed only the deserialized body (shape
varied by version; some versions returned `T` directly).

**After:** every client method returns `CompaniesHouseClientResponse<T>`,
which always carries transport metadata:

```diff
- var profile = await client.GetCompanyProfileAsync(companyNumber);
- // profile was the data itself, or null
+ var result = await client.GetCompanyProfileAsync(companyNumber);
+ var profile = result.Data;   // null for non-success responses
+ result.StatusCode;           // now available
+ result.RetryAfter;           // now available - see #181/#182
+ result.IsSuccess;            // convenience check for 2xx
```

Update any code that used the return value directly as the model to go
through `.Data` instead, and consider using `.StatusCode`/`.IsSuccess` for
error handling instead of catching exceptions or checking for `null` alone.

## Default base URI change

**Before:** `https://api.companieshouse.gov.uk/`
(or a similar legacy host, depending on version).

**After:** `https://api.company-information.service.gov.uk/`
(`CompaniesHouseUris.Default`).

If you previously passed a base URI explicitly, no change is needed. If you
relied on the implicit default, verify it now resolves to the new host - your
existing API key works against both.

## DI package changes

**Before:**

```csharp
services.AddCompaniesHouseClient("Your API Key");
```

**After:** the same call still works, plus new overloads built on
`IOptions<CompaniesHouseClientOptions>`:

```csharp
// Still works
services.AddCompaniesHouseClient(apiKey);

// New: configure via a delegate
services.AddCompaniesHouseClient(options =>
{
    options.ApiKey = apiKey;
    options.BaseUri = CompaniesHouseUris.Default;
});

// New: bind from IConfiguration
services.AddCompaniesHouseClient(configuration); // reads the "CompaniesHouse" section

// New: customise the underlying IHttpClientBuilder
services.AddCompaniesHouseClient(apiKey, builder => builder.AddStandardResilienceHandler());
```

Document-endpoint registration follows the same pattern via
`AddCompaniesHouseDocumentClient`, reading from the `CompaniesHouseDocument`
configuration section by default.

## Test stack (if you forked/contributed tests)

Tests moved from NUnit + FluentAssertions to **xUnit + Shouldly** (Fluent
Assertions' license changed to a paid tier from v8):

```diff
- [Test]
- public void Should_return_active_status()
- {
-     result.CompanyStatus.Should().Be(CompanyStatus.Active);
- }
+ [Fact]
+ public void Should_return_active_status()
+ {
+     result.CompanyStatus.ShouldBe(CompanyStatus.Active);
+ }
```

## Getting help

If you hit a migration issue not covered here, please open an issue at
<https://github.com/kevbite/CompaniesHouse.NET/issues>.

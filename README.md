# CompaniesHouse.NET

A .NET client for the [Companies House Public Data API](https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference).

[![install from nuget](http://img.shields.io/nuget/v/CompaniesHouse.svg?style=flat-square)](https://www.nuget.org/packages/CompaniesHouse)
[![downloads](http://img.shields.io/nuget/dt/CompaniesHouse.svg?style=flat-square)](https://www.nuget.org/packages/CompaniesHouse)
[![Build status](https://github.com/kevbite/CompaniesHouse.NET/actions/workflows/continuous-integration-workflow.yml/badge.svg)](https://github.com/kevbite/CompaniesHouse.NET/actions/workflows/continuous-integration-workflow.yml)

> **Upgrading from an earlier version?** This is a major, deliberately breaking
> rewrite. See [MIGRATION.md](MIGRATION.md) for the full list of changes and
> before/after snippets.

## Installation

Two NuGet packages are published:

```powershell
# The core client and all request/response models
dotnet add package CompaniesHouse

# Optional: DI helpers for ASP.NET Core / generic-host apps
dotnet add package CompaniesHouse.Extensions.Microsoft.DependencyInjection
```

Both packages multi-target `net8.0`, `net9.0` and `net10.0`.

## Getting an API key

Register an application on the
[Companies House developer hub](https://developer.company-information.service.gov.uk/)
to get an API key for the public data API.

## Getting started

### Constructing the client directly

```csharp
using CompaniesHouse;

var settings = new CompaniesHouseSettings(apiKey);

using var client = new CompaniesHouseClient(settings);
```

`CompaniesHouseClient` implements `IDisposable` - always dispose it (or wrap it
in a `using` block) once you're done, since it owns an underlying `HttpClient`.

You can also construct the client from your own `HttpClient` (useful in tests,
or when you want full control over handlers/base address):

```csharp
using var httpClient = new HttpClient { BaseAddress = CompaniesHouseUris.Default };
httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{apiKey}:")));

using var client = new CompaniesHouseClient(httpClient);
```

### Dependency injection

Install `CompaniesHouse.Extensions.Microsoft.DependencyInjection` and register
the client on your `IServiceCollection`. Several overloads are available,
built on `IOptions<CompaniesHouseClientOptions>`:

```csharp
// Simplest - just an API key
services.AddCompaniesHouseClient(apiKey);

// A custom base URI (e.g. against a sandbox/test host)
services.AddCompaniesHouseClient(new Uri("https://api.company-information.service.gov.uk/"), apiKey);

// Full control via a delegate
services.AddCompaniesHouseClient(options =>
{
    options.ApiKey = apiKey;
    options.BaseUri = CompaniesHouseUris.Default;
});

// Bind from IConfiguration (defaults to the "CompaniesHouse" section)
services.AddCompaniesHouseClient(configuration);
```

Every overload also accepts an optional `configureHttpClientBuilder` delegate,
letting you customise the underlying `IHttpClientBuilder` (e.g. to add Polly
resilience handlers):

```csharp
services.AddCompaniesHouseClient(apiKey, builder => builder.AddStandardResilienceHandler());
```

Once registered, inject `ICompaniesHouseClient` - the main facade interface -
into your dependencies:

```csharp
public class MyPageModel(ICompaniesHouseClient client) : PageModel
{
    // ...
}
```

Document endpoints (`GetDocumentMetadataAsync`/`DownloadDocumentAsync`) talk to
a separate host and are registered independently via
`AddCompaniesHouseDocumentClient`, with the same set of overloads.

### `IConfiguration` example

```json
{
  "CompaniesHouse": {
    "ApiKey": "your-api-key",
    "BaseUri": "https://api.company-information.service.gov.uk/"
  }
}
```

```csharp
services.AddCompaniesHouseClient(builder.Configuration);
```

## Enum/value-type handling

Every "enum" in the Companies House API (company status, officer role, charge
type, etc.) is modelled as a **string-backed, readonly `record struct`**
rather than a plain C# `enum`. This is deliberate: Companies House regularly
adds new wire values, and a plain `enum` throws (or silently defaults) the
moment it sees one it doesn't recognise. See the
[design rationale](https://kevsoft.net/2026/06/28/enums-in-api-contracts.html)
for the full background.

```csharp
CompanyStatus status = companyProfile.CompanyStatus;

status.Value;       // the raw wire value, e.g. "active"
status.HasValue;     // false only for the default/absent value
status.IsKnown;      // true if this library recognises the value
status.Description;  // a friendly description for known values, e.g. "Active"
```

Compare against the generated static members (`CompanyStatus.Active`,
`CompanyStatus.Dissolved`, ...) rather than raw strings, and always keep a
fallback arm for values you don't recognise yet:

```csharp
var description = status switch
{
    _ when status == CompanyStatus.Active => "is active",
    _ when status == CompanyStatus.Dissolved => "is dissolved",
    _ when status.IsKnown => status.Description,
    _ => $"unrecognised status: {status.Value}", // never throws
};
```

New values ship as a new minor version of the `CompaniesHouse` package (the
value types are generated from the official
[`api-enumerations`](https://github.com/companieshouse/api-enumerations) data)
- you never need to hand-edit or wait on a code change to keep deserializing.

## Reading responses

Every client method returns a `CompaniesHouseClientResponse<T>`, which carries
transport metadata alongside the deserialized body:

```csharp
var result = await client.GetCompanyProfileAsync(companyNumber);

result.StatusCode;   // the HTTP status code, e.g. 200 or 404
result.IsSuccess;    // true for 2xx responses
result.ReasonPhrase; // the HTTP reason phrase, if any
result.RetryAfter;   // the Retry-After header value, if present (e.g. on 429s)
result.Headers;      // the raw response headers
result.Data;         // the deserialized body, or default for non-success responses
```

`Data` is `null`/`default` (rather than throwing) when the API returns a
non-success response, so check it (or `IsSuccess`) before using it:

```csharp
var result = await client.GetCompanyProfileAsync(companyNumber);
if (result.Data is null)
{
    // no match for that company number (404), or another non-success response
    return;
}
```

## Usage

### Searching for resources

```csharp
var request = new SearchAllRequest
{
    Query = "Jay2Base",
    StartIndex = 0,
    ItemsPerPage = 10
};

var result = await client.SearchAllAsync(request);

foreach (var item in result.Data.Items)
{
    // Do something...
}
```

For a specific resource type, use `SearchCompanyAsync`, `SearchOfficerAsync`,
`SearchDisqualifiedOfficerAsync`, `SearchCompaniesAlphabeticallyAsync`,
`SearchDissolvedCompaniesAsync` or `AdvancedCompanySearchAsync` with the
matching request type.

```csharp
var companies = await client.SearchCompanyAsync(new SearchCompanyRequest { Query = "Jay2Base" });
var officers = await client.SearchOfficerAsync(new SearchOfficerRequest { Query = "Jay2Base" });
var disqualified = await client.SearchDisqualifiedOfficerAsync(new SearchDisqualifiedOfficerRequest { Query = "Jay2Base" });
```

### Getting a company profile

```csharp
var result = await client.GetCompanyProfileAsync("10440441");
```

`result.Data` is `null` if there was no match for that company number.

### Getting the company officer list

```csharp
var result = await client.GetOfficersAsync("03977902");

// Optionally page the results
var page = await client.GetOfficersAsync("03977902", startIndex: 10, pageSize: 10);
```

A single officer appointment can be fetched directly:

```csharp
var officer = await client.GetOfficerByAppointmentIdAsync("03977902", appointmentId);
```

### Getting officer appointments

```csharp
var result = await client.GetAppointmentsAsync(officerId, startIndex: 0, pageSize: 25);
```

### Getting the company filing history

```csharp
var result = await client.GetCompanyFilingHistoryAsync("10440441", startIndex: 0, pageSize: 25);

var item = await client.GetFilingHistoryByTransactionAsync("10440441", transactionId);
```

### Getting company insolvency information

```csharp
var result = await client.GetCompanyInsolvencyInformationAsync("10440441");
```

`result.Data` is `null` if there is no insolvency information for the company.

### Getting persons with significant control

```csharp
var result = await client.GetPersonsWithSignificantControlAsync("10440441", startIndex: 0, pageSize: 25);
```

### Getting charges

```csharp
var charges = await client.GetChargesListAsync("10440441", startIndex: 0, pageSize: 25);

var charge = await client.GetChargeByIdAsync("10440441", chargeId);
```

### Getting the registered office address

```csharp
var result = await client.GetRegisteredOfficeAddress("10440441");
```

### Getting document metadata and downloading a document

```csharp
var metadata = await client.GetDocumentMetadataAsync("FIxRR8teCKodjkBLRDHv2Cb8y0-nQ7T5G3BEXfWtOu4");

var document = await client.DownloadDocumentAsync("FIxRR8teCKodjkBLRDHv2Cb8y0-nQ7T5G3BEXfWtOu4");
```

`result.Data` is `null` if there was no metadata/document for the given id.

More endpoints land progressively - see `.plans/` for what's in flight.

## Sample project

A runnable end-to-end example, covering direct construction, DI registration,
search, company profile, officers, and gracefully handling an unrecognised
enum value, lives in [`samples/SampleProject`](samples/SampleProject).

## Contributing

1. Fork
1. Hack!
1. Pull Request

See [AGENTS.md](AGENTS.md) for repository conventions, build/test commands and
the design decisions behind the v-next rewrite.

## Running tests

```powershell
dotnet restore
dotnet build -c Release
dotnet test  -c Release
```

Integration tests hit the real Companies House API and need an API key in the
`COMPANIES_HOUSE_API_KEY` environment variable - they're skipped/fail without
one, which is expected when working offline.

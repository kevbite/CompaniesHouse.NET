# 02 — DI extensions with IOptions<>

**Status:** complete
**Depends on:** `01-core-client-architecture`
**Blocks:** nothing (parallel with endpoints)

## Goal

Modernise `CompaniesHouse.Extensions.Microsoft.DependencyInjection` to use the
`IOptions<>` pattern (`AddOptions`, `IConfiguration` binding, validation) and
provide clean overloads to configure the client several ways.

## Why

The current extension stashes a `CompaniesHouseClientOptions` as a singleton it
news-up by hand, rather than using the framework's options pipeline. It also
targets `netstandard2.0` and pins `Microsoft.Extensions.*` to `3.1.9`. A new
major is the time to adopt the idiomatic options approach and let consumers bind
from configuration and validate on start.

## Scope

### Options type
- Define `CompaniesHouseClientOptions` (name/section e.g. `"CompaniesHouse"`)
  with at least `BaseUri`, `ApiKey`, and room for future knobs (timeouts,
  document API base URI). Add **`DataAnnotations`** (`[Required]` ApiKey, valid
  `Uri`) for validation.
- Provide a defaulted `BaseUri` (current CH host — see plan `01`).

### Registration via the options pipeline
- Use `services.AddOptions<CompaniesHouseClientOptions>()` with:
  - `.Bind(configuration.GetSection("CompaniesHouse"))`
  - `.Configure(...)` for the delegate overloads
  - `.ValidateDataAnnotations()`
  - `.ValidateOnStart()`
- Register the client as a **typed `HttpClient`**
  (`AddHttpClient<ICompaniesHouseClient, CompaniesHouseClient>`) and set
  `BaseAddress` from resolved options.
- Keep `services.TryAdd*` for all sub-client interfaces resolving from the
  single `ICompaniesHouseClient` (issue #190 — libraries should use `TryAdd`;
  already done, preserve it).
- Register `IApiKeyProvider` (default `StaticApiKeyProvider` from options),
  overridable by consumers (issues #192/#194).

### Overloads (multiple ways to configure)
Provide these entry points:
1. `AddCompaniesHouseClient(string apiKey)`
2. `AddCompaniesHouseClient(Uri baseUri, string apiKey)`
3. `AddCompaniesHouseClient(Action<CompaniesHouseClientOptions> configure)`
4. `AddCompaniesHouseClient(Action<IServiceProvider, CompaniesHouseClientOptions> configure)`
5. `AddCompaniesHouseClient(IConfiguration section)` /
   `AddCompaniesHouseClient(IConfiguration config, string sectionName = "CompaniesHouse")`
6. A named/keyed variant so multiple configured clients can coexist (optional —
   note if deferred).
- Allow the caller to customise the underlying `IHttpClientBuilder` (return it,
  or accept a `Action<IHttpClientBuilder>`), so Polly/resilience handlers can be
  added.

### Packaging
- Retarget to `net8.0;net9.0;net10.0`, versions via `Directory.Packages.props`.
- Bump `Microsoft.Extensions.*` to versions matching the target frameworks.

## Tasks

- [ ] Add DataAnnotations validation to `CompaniesHouseClientOptions`.
- [ ] Rewrite registration around `AddOptions` + `ValidateOnStart`.
- [ ] Add the `IConfiguration`-binding overloads.
- [ ] Keep `TryAdd` sub-client registrations; add new sub-clients as endpoints land.
- [ ] Return `IHttpClientBuilder` (or expose a hook) for resilience config.
- [ ] Update DI tests (plan `10`) for the new surface.

## Design decisions

- **`IOptions<>` + `ValidateOnStart`** — fail fast on a missing/invalid API key
  instead of at first request.
- **Config binding** — first-class `appsettings.json` support.

## Open questions

- Do we ship keyed/named multi-client support in v-next or defer? (Assumption:
  design the API so it can be added later; defer the actual keyed overloads
  unless cheap.)
- Section name default: `"CompaniesHouse"` — confirm.

## Acceptance criteria

- `services.AddCompaniesHouseClient(Configuration.GetSection("CompaniesHouse"))`
  binds and validates; a missing API key fails at startup.
- All previously-registered sub-client interfaces still resolve.
- No `Newtonsoft.Json`; builds on all target frameworks.

## References

- Issues #190 (TryAdd), #192/#194 (API key from anywhere), #193 (TryAdd PR).

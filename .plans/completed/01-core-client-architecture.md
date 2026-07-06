# 01 — Core client architecture

**Status:** complete
**Depends on:** `00-foundation`
**Blocks:** all endpoint plans (`06`+)

## Goal

Establish the core client plumbing for the new major version: the
`CompaniesHouseClient` facade, the per-capability sub-client pattern,
`System.Text.Json` serialization, a redesigned response wrapper, and consistent
error handling. This is the skeleton every endpoint hangs off.

## Why

The old client wires up ~11 sub-clients by hand in a constructor, uses
`Newtonsoft.Json`, and returns a bare `CompaniesHouseClientResponse<T>` that
carries only `Data`. Consumers have repeatedly asked for richer responses
(status code, headers, retry-after) and the serialization stack must move to
STJ.

## Scope

### Entry point & sub-client pattern (keep the shape)
- `CompaniesHouseClient : ICompaniesHouseClient` remains the single entry point.
- Every capability is its own sub-client behind its own interface
  (`ICompaniesHouseSearchClient`, `ICompaniesHouseCompanyProfileClient`, ...),
  aggregated by `ICompaniesHouseClient`. Preserve this — it is a deliberate,
  liked design.
- Keep the two construction paths:
  - `new CompaniesHouseClient(HttpClient)` — bring-your-own `HttpClient`
    (the DI/`IHttpClientFactory` path).
  - `new CompaniesHouseClient(settings)` — convenience path that builds an
    `HttpClient` with the auth handler.
- Keep the small **URI builder** types per endpoint; they are unit-testable and
  already proven. New endpoints follow the same pattern.

### Serialization: System.Text.Json
- Central `JsonSerializerOptions` factory used by every sub-client:
  - `PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower` (API is
    snake_case) — verify member-by-member with `[JsonPropertyName]` where the
    policy is insufficient.
  - Register the string-backed value-type converters (plan `03`).
  - Custom converters for CH's quirky date formats (`yyyy-MM-dd` and partial
    dates like month/year only — see old `OptionalDateJsonConverter`).
  - `NumberHandling = AllowReadingFromString` where the API returns numbers as
    strings (issue #212: `total_results`/`items_per_page`/`start_index` came
    back as strings for SearchAll).
- Prefer **`System.Text.Json` source-generation** (`JsonSerializerContext`) for
  the response models to stay trim/AOT-friendly and fast. Decide whether to
  require this for all models or adopt incrementally.
- Delete every `Newtonsoft.Json`-based converter under `JsonConverters/` and
  reimplement the needed ones for STJ.

### Response & error model (redesign — issues #181, #182, #189)
- Redesign the response wrapper so callers can see transport metadata, not just
  the body. Candidate shape:
  ```csharp
  public sealed class CompaniesHouseClientResponse<T>
  {
      public T? Data { get; }
      public int StatusCode { get; }
      public string? ReasonPhrase { get; }
      public TimeSpan? RetryAfter { get; }        // 429 handling (#181/#182)
      public bool IsSuccess { get; }
      // headers exposed read-only
  }
  ```
- Define the semantics for **not found**: today several `GetX` methods return
  `null` data on 404. Decide between "null data + `IsSuccess=false`" vs a
  dedicated result type, and document it. (Assumption: keep returning a
  response with `Data == null` for 404 on single-resource gets, but surface
  `StatusCode`.)
- Replace `EnsureSuccessStatusCode2()` with explicit handling that captures the
  status/headers/retry-after before throwing (or before returning a non-success
  response). Define the exception type(s) for genuine errors.

### Auth & settings
- Keep `IApiKeyProvider` abstraction (issues #192/#194 want the key pulled from
  arbitrary locations) — the DI layer (plan `02`) supplies implementations.
- Keep `CompaniesHouseAuthorizationHandler` (Basic auth: API key as username).
- Confirm the base URI: the old default is `https://api.companieshouse.gov.uk/`
  but the current spec host is `https://api.company-information.service.gov.uk/`
  — **update the default** and note it as a breaking change.

## Tasks

- [ ] Add the STJ `JsonSerializerOptions` factory + `JsonSerializerContext`.
- [ ] Port/replace date and number converters for STJ.
- [ ] Redesign `CompaniesHouseClientResponse<T>` (status/headers/retry-after).
- [ ] Rework the HTTP send/deserialize pipeline shared by sub-clients.
- [ ] Update the default base URI to the current CH host.
- [ ] Remove all `Newtonsoft.Json` usage from `src/CompaniesHouse`.
- [ ] Keep `CompaniesHouseClient` + sub-client interfaces as the public shape.

## Design decisions

- **Sub-client-per-capability** preserved — good separation, already liked.
- **STJ everywhere**, ideally source-generated — perf + trimming/AOT.
- **Richer response wrapper** — directly resolves long-standing requests.

## Open questions

- One `JsonSerializerContext` for the whole assembly, or per-endpoint? (Lean:
  one shared context.)
- Do we keep throwing on non-2xx, or always return a response and let callers
  branch on `IsSuccess`? (Lean: return response for expected 404s; throw for
  unexpected 5xx/transport — finalise here.)

## Acceptance criteria

- A trivial call (e.g. company profile) round-trips via STJ with no Newtonsoft.
- Response exposes status code + retry-after on both success and failure.
- All sub-clients share one serialization + send pipeline.

## References

- Issues #181/#182 (headers/retry-after), #189 (response redesign), #188 (STJ),
  #212 (numbers-as-strings), #156 (raw values), #202 (auth specifics).
- API host: `api.company-information.service.gov.uk` (see `swagger.json`).

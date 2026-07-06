# 12 — Discriminated union response type (issue #189)

**Status:** outstanding
**Depends on:** `01-core-client-architecture` (complete)
**Blocks:** nothing — but improves ergonomics for all endpoint consumers

## Goal

Replace the flat `CompaniesHouseClientResponse<T>` (with a nullable `Data` and
an `IsSuccess` flag callers must remember to check) with a proper **discriminated
union** — an abstract base type `CompaniesHouseResponse<T>` whose sealed nested
subtypes represent every distinct HTTP outcome the API produces. Consumers
pattern-match on the concrete type; the compiler guides them rather than silent
null-reference bugs.

This directly implements the original intent of issue #189 ("a base class …
switching based on the concrete class") and supersedes the interim shape shipped
in plan `01`.

## Why

The current flat class has two problems:

1. **`Data` is always nullable.** Even on success, callers must write
   `if (response.IsSuccess && response.Data is not null)`. There is nothing
   stopping them from reading `response.Data` on a 404 and getting `null`
   silently.
2. **Semantics are collapsed.** A 404, a 429, and a 401 are three very different
   situations with different recovery paths. Today they all look the same to the
   compiler: `IsSuccess == false`. Callers must remember to inspect `StatusCode`
   themselves.

A sealed type hierarchy solves both: `Success.Data` is always non-null (no `?`),
and the switch/is-pattern forces the caller to reason about each outcome.

## Proposed shape

```csharp
/// <summary>
/// Discriminated union representing every HTTP outcome of a Companies House API
/// call. Transport failures (network errors, DNS, timeout) surface as
/// <see cref="System.Net.Http.HttpRequestException"/> from the underlying HttpClient.
/// </summary>
public abstract class CompaniesHouseResponse<T>
{
    // Private constructor — no external subclassing.
    private CompaniesHouseResponse(int statusCode, string? reasonPhrase)
    {
        StatusCode    = statusCode;
        ReasonPhrase  = reasonPhrase;
    }

    /// <summary>The HTTP status code of the response.</summary>
    public int StatusCode { get; }

    /// <summary>The HTTP reason phrase, if any.</summary>
    public string? ReasonPhrase { get; }

    /// <summary>
    /// Returns the deserialized response body when this is a <see cref="Success"/>
    /// response. Throws <see cref="InvalidOperationException"/> for any other subtype,
    /// making the error explicit rather than silently returning null.
    /// Use pattern matching when you need to handle non-success outcomes.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the response is not <see cref="Success"/>.
    /// </exception>
    public T Data => this is Success s
        ? s.Data
        : throw new InvalidOperationException(
            $"Cannot access Data on a {GetType().Name} response (HTTP {StatusCode}).");

    // ─── Subtypes ────────────────────────────────────────────────────────────

    /// <summary>A 2xx response whose body deserialized successfully.</summary>
    public sealed class Success : CompaniesHouseResponse<T>
    {
        public Success(T data, int statusCode, string? reasonPhrase, HttpResponseHeaders headers)
            : base(statusCode, reasonPhrase)
        {
            Data    = data;
            Headers = headers;
        }

        /// <summary>The deserialized response body. Never null on this subtype.</summary>
        public T Data { get; }

        /// <summary>The full set of response headers.</summary>
        public HttpResponseHeaders Headers { get; }
    }

    /// <summary>
    /// A 404 response — the requested resource does not exist or is not
    /// accessible with the provided credentials.
    /// </summary>
    public sealed class NotFound : CompaniesHouseResponse<T>
    {
        public NotFound(int statusCode, string? reasonPhrase) : base(statusCode, reasonPhrase) {}
    }

    /// <summary>
    /// A 429 response — the client has been rate-limited. Check
    /// <see cref="RetryAfter"/> before retrying.
    /// </summary>
    public sealed class RateLimited : CompaniesHouseResponse<T>
    {
        public RateLimited(TimeSpan? retryAfter, int statusCode, string? reasonPhrase)
            : base(statusCode, reasonPhrase) => RetryAfter = retryAfter;

        /// <summary>How long to wait before retrying, if the server supplied the header.</summary>
        public TimeSpan? RetryAfter { get; }
    }

    /// <summary>
    /// A 401/403 response — the API key is missing, wrong, or lacks permission.
    /// </summary>
    public sealed class Unauthorized : CompaniesHouseResponse<T>
    {
        public Unauthorized(int statusCode, string? reasonPhrase) : base(statusCode, reasonPhrase) {}
    }

    /// <summary>
    /// Any other 4xx response not covered by the more specific subtypes.
    /// </summary>
    public sealed class ClientError : CompaniesHouseResponse<T>
    {
        public ClientError(int statusCode, string? reasonPhrase) : base(statusCode, reasonPhrase) {}
    }

    /// <summary>
    /// A 5xx response — the server encountered an error. May carry a
    /// <see cref="RetryAfter"/> hint (e.g. 503 with <c>Retry-After</c>).
    /// </summary>
    public sealed class ServerError : CompaniesHouseResponse<T>
    {
        public ServerError(TimeSpan? retryAfter, int statusCode, string? reasonPhrase)
            : base(statusCode, reasonPhrase) => RetryAfter = retryAfter;

        /// <summary>How long to wait before retrying, if the server supplied the header.</summary>
        public TimeSpan? RetryAfter { get; }
    }
}
```

All HTTP-level outcomes — including 5xx — are returned as subtypes. Genuine
transport failures (network errors, DNS, timeout) still surface as
`HttpRequestException` from the underlying `HttpClient` and are not caught by
this library.

### How consumers use this

**Simple happy path** — just grab `.Data` and let it throw on failure:

```csharp
var company = (await client.GetCompanyProfileAsync("12345678")).Data;
Console.WriteLine(company.CompanyName);
```

**Full branching** — pattern match when you need to handle each outcome:

switch (response)
{
    case CompaniesHouseResponse<CompanyProfile>.Success { Data: var company }:
        Console.WriteLine(company.CompanyName);
        break;

    case CompaniesHouseResponse<CompanyProfile>.NotFound:
        Console.WriteLine("Company not found.");
        break;

    case CompaniesHouseResponse<CompanyProfile>.RateLimited { RetryAfter: var delay }:
        Console.WriteLine($"Rate limited. Retry after {delay}.");
        break;

    case CompaniesHouseResponse<CompanyProfile>.Unauthorized:
        Console.WriteLine("Check your API key.");
        break;

    case CompaniesHouseResponse<CompanyProfile>.ServerError { RetryAfter: var delay, StatusCode: var code }:
        Console.WriteLine($"Server error {code}. Retry after {delay}.");
        break;

    default:
        Console.WriteLine($"Unexpected response: {response.StatusCode}");
        break;
}
```

### Decision: keep or rename the type?

`CompaniesHouseClientResponse<T>` → `CompaniesHouseResponse<T>`.

The `Client` infix adds no value and the shorter name reads more naturally as a
return type. This is a deliberate breaking-change rename.

## Scope

### Breaking changes (expected — new major version)

- `CompaniesHouseClientResponse<T>` removed and replaced by
  `CompaniesHouseResponse<T>` with the subtype hierarchy above.
- All sub-client interfaces change from
  `Task<CompaniesHouseClientResponse<T>>` to `Task<CompaniesHouseResponse<T>>`.
- All sub-client implementations updated.
- `HttpResponseMessageExtensions.ToCompaniesHouseClientResponseAsync<T>` renamed
  and updated to return the appropriate subtype.

### In-scope

- New `CompaniesHouseResponse<T>` abstract class with **six** sealed subtypes
  (`Success`, `NotFound`, `RateLimited`, `Unauthorized`, `ClientError`,
  `ServerError`).
- Update `HttpResponseMessageExtensions` pipeline to build the correct subtype
  from the `HttpResponseMessage`.
- Update every `ICompaniesHouseX` interface and implementation to use the new
  return type.
- Tests: unit tests for each subtype (factory method / pipeline), plus scenario
  tests verifying that a real 404 returns `NotFound`, a real success returns
  `Success`, and so on.

### Out of scope

- No changes to request models, URI builders, or the `CompaniesHouseSettings`
  hierarchy.

## Tasks

- [ ] Define `CompaniesHouseResponse<T>` abstract class with the **six** subtypes in
      `src/CompaniesHouse/CompaniesHouseResponse.cs`. Delete
      `CompaniesHouseClientResponse.cs` and `CompaniesHouseApiException.cs`.
- [ ] Update `HttpResponseMessageExtensions.ToCompaniesHouseResponseAsync<T>` to
      classify the response:
      - 2xx → `Success` (deserialize body, expose full `Headers`)
      - 404 → `NotFound`
      - 429 → `RateLimited` (parse `Retry-After`)
      - 401/403 → `Unauthorized`
      - 5xx → `ServerError` (parse `Retry-After` — e.g. 503)
      - other 4xx → `ClientError`
- [ ] Update every `ICompaniesHouseX` interface return type.
- [ ] Update every sub-client implementation return type (callers of the pipeline
      need no other changes since the extension method does the heavy lifting).
- [ ] Update unit tests in `CompaniesHouse.Tests` for the new type/subtypes.
- [ ] Add scenario-level tests:
      - Valid company number → `Success` with non-null `Data`.
      - Nonexistent company number → `NotFound`.
      - Confirm `RateLimited` surfaces `RetryAfter` (may need a mock/stub if
        hitting the real API isn't reliable here).
      - Confirm `ServerError` surfaces `RetryAfter` for a mocked 503.
- [ ] Update the sample project (`samples/SampleProject`) to use pattern matching
      on the new type.
- [ ] Update `99-recurring-issues-backlog.md`: mark the #189 / #181 / #182
      response-ergonomics row as resolved.

## Design decisions

- **`.Data` on the base throws for non-success** — provides a one-liner for the
  happy path (`response.Data`) while making the failure explicit via
  `InvalidOperationException` rather than silently returning null. Callers who
  need to branch use pattern matching; callers who expect success use `.Data`
  directly.
- **Private base constructor** — prevents external subclassing; the compiler
  knows the hierarchy is closed (exhaustiveness via `default` in switch).
- **`T Data` not `T? Data`** — `Success.Data` is non-nullable; callers get a
  compile-time guarantee that Data is present on success.
- **5xx returns `ServerError`, not throws** — 5xx responses can carry a
  `Retry-After` header (e.g. 503) and callers may have valid recovery logic.
  Returning a type keeps all HTTP-level outcomes consistent. Genuine transport
  failures (`HttpRequestException`) still propagate naturally from `HttpClient`.
- **`CompaniesHouseApiException` removed** — all HTTP-level errors are now
  represented as subtypes; the exception class is no longer needed.
- **`Success` exposes full `HttpResponseHeaders`** — raw headers are surfaced
  on `Success` so callers can inspect anything the API returns; parsed
  well-known values (`RetryAfter`) are exposed as typed properties on the
  relevant error subtypes.
- **No non-generic `CompaniesHouseResponse` base** — callers always work with
  the typed `CompaniesHouseResponse<T>` variant; a non-generic base would add a
  layer with no tangible benefit.
- **`CompaniesHouseResponse<T>` not `Result<T>`** — domain-namespaced name is
  clearer to consumers unfamiliar with result-type patterns.

## Acceptance criteria

- All existing tests pass with updated type names.
- `CompaniesHouseClientResponse<T>` and `CompaniesHouseApiException` do not
  exist anywhere in the solution.
- A switch over `CompaniesHouseResponse<CompanyProfile>` without a `default`
  branch produces a compiler warning (exhaustiveness via sealed hierarchy).
- Scenario tests confirm: 404 → `NotFound`, 2xx → `Success` with non-null
  `Data`, mocked 503 → `ServerError` with `RetryAfter` populated.

## References

- Issue #189 — "Ideas for changing the CompaniesHouseClientResponse class"
- Issues #181/#182 — include StatusCode, ReasonPhrase, RetryAfter on failures
- Plan `01` — core architecture (response wrapper originally introduced here)

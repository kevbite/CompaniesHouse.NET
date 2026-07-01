# AGENTS.md

Guidance for AI agents (and humans) working in this repository. Read this
before making changes, then read the relevant plan in `.plans/outstanding/`.

## What this project is

`CompaniesHouse.NET` is a .NET client SDK for the
[Companies House Public Data API](https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference).
It is published as two NuGet packages:

- **`CompaniesHouse`** — the core client (`CompaniesHouseClient`) and all
  request/response models.
- **`CompaniesHouse.Extensions.Microsoft.DependencyInjection`** — DI helpers
  for registering the client with `IServiceCollection`.

## Current state: a v-next rewrite

We are building a **new major version** on the `prerelease` branch. Breaking
changes are expected and welcome. The old surface lives on `master` and can be
referenced for behaviour, but we are rebuilding the client endpoint-by-endpoint
from the official API documentation rather than porting the old code verbatim.

**The single source of truth for the work is `.plans/`.** Do not freelance a
large redesign — pick up an outstanding plan, refine it if needed, and execute
it.

## Non-negotiable design decisions

These are settled for the new major version. Do not reverse them without
updating the relevant plan and calling it out explicitly.

1. **Multi-target `net8.0;net9.0;net10.0`.** No `netstandard`, no `net45`. Drop
   the `Microsoft.NETFramework.ReferenceAssemblies` and `Microsoft.Net.Http`
   references.
2. **`System.Text.Json` only.** Remove every reference to `Newtonsoft.Json`
   (see issue #188). No new dependency on Json.NET in any project, including
   tests.
3. **No plain C# `enum`s on the wire.** Every API "enum" is modelled as a
   **string-backed `readonly record struct`** that preserves the raw value and
   never throws on an unrecognised value. See
   `.plans/outstanding/03-string-backed-value-types.md` and the design blog
   post: <https://kevsoft.net/2026/06/28/enums-in-api-contracts.html>.
4. **Enum values are generated, not hand-written.** A Roslyn **source
   generator** produces the string-backed types from the Companies House
   [`api-enumerations`](https://github.com/companieshouse/api-enumerations)
   YAML (pulled in as a git submodule) plus our own local "extra" lists. We
   ship a new package version to pick up new values — we do not hand-edit
   generated types. See plans `04` and `05`.
5. **`CompaniesHouseClient` stays the entry point.** Every capability hangs off
   it as its own focused sub-client (e.g. search, company profile, officers),
   each behind its own interface, exactly as today.
6. **DI uses `IOptions<>`.** The DI package uses `AddOptions`,
   `IConfiguration` binding and validation, with overloads to configure the
   client several ways. See `.plans/outstanding/02-di-extensions-ioptions.md`.
7. **`nullable` reference types enabled** across all projects.
8. **Test stack: xUnit + Shouldly.** No NUnit, no FluentAssertions (license
   changed to a paid tier from v8). Use `[Fact]`/`[Theory]`/`[MemberData]` and
   `IAsyncLifetime` for async setup/teardown; assert with Shouldly's
   `.ShouldBe(...)` family. For deep object-graph comparisons against test
   fixtures that hold raw wire strings, use the repo's own
   `EquivalencyAssertionExtensions.ShouldBeEquivalentTo(...)` helper in
   `CompaniesHouse.Tests` (bridges enum <-> wire string, no FluentAssertions
   `IEquivalencyStep` needed).

## Repository layout

```
src/
  CompaniesHouse/                                  core client + models
  CompaniesHouse.Extensions.Microsoft.DependencyInjection/  DI helpers
  (planned) CompaniesHouse.SourceGenerator/        enum value-type generator
tests/
  CompaniesHouse.Tests/                            unit tests
  CompaniesHouse.IntegrationTests/                 hit the real API (needs key)
  CompaniesHouse.ScenarioTests/                    end-to-end behaviour
  CompaniesHouse.Extensions.*.Tests/               DI tests
samples/SampleProject/                             runnable usage sample
external/api-enumerations/                         (planned) git submodule
swagger.json                                       partial CH OpenAPI 2.0 spec
CompaniesHouse.slnx                                solution (XML .slnx format)
.plans/                                            the work breakdown (read this)
```

## Conventions

- **File-scoped namespaces**, `ImplicitUsings` enabled, `LangVersion` latest.
- **Warnings are errors** (`TreatWarningsAsErrors=true`) — keep the build clean.
- One public type per file; interface `IThing` lives next to `Thing`.
- URLs are built with small, testable **URI builder** types (see
  `src/CompaniesHouse/UriBuilders`). Keep this pattern for new endpoints.
- Async methods take a `CancellationToken` (defaulted) and end in `Async`.
- JSON property names come from the API (snake_case); map with
  `[JsonPropertyName(...)]` or a snake_case naming policy — never rename the
  wire contract.
- Prefer **central package management**: versions live in
  `Directory.Packages.props`, not in individual `.csproj` files.

## Build, test, format

Run from the repository root.

```powershell
dotnet restore
dotnet build -c Release
dotnet test  -c Release            # unit + scenario tests
dotnet format --verify-no-changes  # style gate
```

Integration tests need a Companies House API key in the `api_key` environment
variable and are skipped/failed without one — do not treat their absence as a
regression when working offline.

## Working agreement for agents

- **Pick up a plan** from `.plans/outstanding/`. Work in the order implied by
  the numeric prefixes (foundation first) unless the plan says otherwise.
- **Keep changes surgical and endpoint-scoped.** Build the client up
  gradually; do not rewrite everything in one pass.
- **Update the plan as you learn.** Plans are living documents — refine tasks,
  record decisions, and note open questions.
- **When a plan is fully delivered and verified, move its file** from
  `.plans/outstanding/` to `.plans/completed/` in the same change.
- **Design for the recurring issues.** A huge share of historical bug reports
  are "new enum value broke deserialisation" (#168, #185, #186, #197, #200,
  #201, #209, #218) and "missing field on a response" (#205, #206, #211, #212,
  #217, #221). The string-backed value types and generator exist to kill the
  first class entirely; model responses faithfully from the docs to avoid the
  second.
- **Cite your sources.** Reference the specific API doc page and/or GitHub
  issue in code comments and PRs when a decision is non-obvious.

## Key references

- API reference: <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference>
- Enumerations repo: <https://github.com/companieshouse/api-enumerations>
- Enum design rationale: <https://kevsoft.net/2026/06/28/enums-in-api-contracts.html>
- Issue tracker: <https://github.com/kevbite/CompaniesHouse.NET/issues>

## Commits
Commit in small amounts with a summary of what work we're building and not include the co-authorized by, however, do not push! Don't commit the .plans folder or the AGENTS.md
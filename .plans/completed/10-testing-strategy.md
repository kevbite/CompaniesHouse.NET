# 10 — Testing strategy

**Status:** complete
**Depends on:** `00-foundation`; runs continuously alongside every plan
**Blocks:** nothing (but gates "done" for each plan)

## Goal

Define and stand up the test approach for v-next so every endpoint and the enum
generator ship with meaningful coverage, and so the historical "it broke in
production on a new value" class of bug is caught by tests.

## Test projects (existing, to modernise)

- `tests/CompaniesHouse.Tests` — fast **unit tests** (URI builders, converters,
  value types, response mapping).
- `tests/CompaniesHouse.ScenarioTests` — **behavioural** tests against canned
  HTTP responses (no network).
- `tests/CompaniesHouse.IntegrationTests` — hit the **real API** (needs the
  `api_key` env var); skipped/soft-failed without it.
- `tests/CompaniesHouse.Extensions.Microsoft.DependencyInjection.Tests` — DI
  registration/resolution tests.

Retarget all to the new TFMs (plan `00`), remove `Newtonsoft.Json` from tests
(issues #177/#178/#195/#196 were all Newtonsoft bumps — delete the dependency),
enable nullable.

## What to test

### Value types & generator (highest priority — this is the whole point)
- **Unknown value never throws**: deserialize a status/type/role string that is
  *not* in the YAML; assert it round-trips and `IsKnown == false`.
- Known values equal their static members; equality/`GetHashCode`; `ToString`.
- Null/empty/absent semantics.
- Prefix helpers (e.g. filing subcategory) where used.
- **Generator snapshot tests**: given a small YAML input, assert the generated
  source matches a checked-in snapshot (use `Microsoft.CodeAnalysis` test host
  or a verify library). Guards against accidental generator regressions.

### Per-endpoint
- **URI builder** unit tests: correct path + query for each param combination,
  proper escaping, and *omission* of optional params (e.g. the `restrictions`
  bug, #203/#204/#208).
- **Deserialization scenario tests**: feed **real sample payloads** (captured
  from the API / docs) through the client via a stubbed `HttpMessageHandler`
  (or WireMock) and assert the mapped model — including the fields that were
  historically missing (`person_number`, `total_results`, `foreign_company_details`,
  `sic_codes`).
- **Numbers-as-strings** (#212), **partial dates**, **404 → null data +
  status** (plan `01`).
- **Error/transport**: 429 surfaces `RetryAfter` (#181/#182); non-2xx surfaces
  status + headers.

### DI
- Every sub-client interface resolves from the container.
- Options bind from `IConfiguration`; missing API key fails `ValidateOnStart`.

## Tooling

- **Test runner: xUnit.** **Assertions: Shouldly.** (NUnit and FluentAssertions
  have been fully removed as of plan `00` — FluentAssertions' license changed
  to a paid tier from v8 onward.) For deep object-graph comparisons that need
  to bridge a raw wire string against a string-backed value type, use the
  repo's own `EquivalencyAssertionExtensions.ShouldBeEquivalentTo(...)` helper
  in `CompaniesHouse.Tests` rather than reaching for a new dependency.
- Add an HTTP stubbing approach for scenario tests (a hand-rolled
  `HttpMessageHandler` stub, or `WireMock.Net`). Decide and standardise.
- Snapshot/verify library for generator output (e.g. `Verify`).
- CI already publishes TRX results — keep that.

## Tasks

- [ ] Retarget test projects; strip Newtonsoft; enable nullable.
- [ ] Establish the HTTP-stub helper for scenario tests.
- [ ] Add value-type + generator snapshot tests.
- [ ] Add a per-endpoint test checklist (mirror plan `09`'s per-endpoint list).
- [ ] Wire integration tests to skip cleanly without `api_key`.

## Acceptance criteria

- `dotnet test -c Release` is green offline (integration tests skip without a
  key).
- Every shipped endpoint has URI-builder + deserialization coverage.
- The generator has snapshot coverage.

## References

- Issues #177/#178/#195/#196 (remove Newtonsoft from tests), #180 (sandbox),
  #181/#182 (error metadata), plus all the endpoint-specific issues in `09`.

## Delivered

Most of this plan's tasks were already satisfied incrementally by plans
`00`/`04`/`06`/`07`/`08`/`09a`-`09g` (xUnit + Shouldly test stack, nullable
enabled, `net10.0`-targeted test projects, no `Newtonsoft.Json` anywhere in
`tests/`, value-type unit tests with unknown-value coverage, real-payload
scenario tests per endpoint). This pass closed the remaining gaps:

- **Integration tests now skip cleanly without `COMPANIES_HOUSE_API_KEY`**
  (previously they'd fail with auth/deserialization errors). Added
  `IntegrationFactAttribute`/`IntegrationTheoryAttribute`
  (`tests/CompaniesHouse.IntegrationTests/IntegrationFactAttribute.cs`,
  `IntegrationTheoryAttribute.cs`) which set `Skip` at attribute-construction
  time when `Keys.ApiKeyOrNull` is null/empty, and applied them to every
  `[Fact]`/`[Theory]` across the whole `CompaniesHouse.IntegrationTests`
  project. Verified: 73/73 pass with the key present, all tests skip cleanly
  (0 failed) with the env var unset.
- **Generator snapshot test** added
  (`tests/CompaniesHouse.SourceGenerator.Tests/ValueTypeEmitterSnapshotTests.cs`)
  - asserts the *entire* generated value-type + JSON-converter source text
    for a representative enum group against a fixed expected string, on top
    of the existing spot-check (`ShouldContain`) assertions in
    `EnumValueTypeGeneratorTests`. No new snapshot-testing package dependency
    was introduced (a plain Shouldly `ShouldBe` on the full source string is
    sufficient and keeps the dependency footprint the same).
- Confirmed already-satisfied items via direct inspection rather than
  re-doing them: `Directory.Build.props` enables `Nullable`/`ImplicitUsings`
  repo-wide; no `Newtonsoft` references anywhere under `tests/`; 429/`RetryAfter`
  and non-2xx/server-error transport behaviour already has dedicated coverage
  in `HttpResponseMessageExtensionsTests`; every endpoint shipped so far
  (search, company profile, officers, and the plan `09a`-`09g` catalogue)
  already carries URI-builder + scenario + integration coverage as part of
  its own plan.

Verification: `dotnet build CompaniesHouse.slnx -c Release` (0 errors),
`CompaniesHouse.Tests` 458/458, `ScenarioTests` 20/20, `SourceGenerator.Tests`
29/29, DI tests 6/6, `IntegrationTests` 73/73 with a key / all skip cleanly
without one, `dotnet format --verify-no-changes` scoped to touched files
(pre-existing unrelated whitespace issues on untouched lines in a handful of
older integration test files were left as-is, consistent with not fixing
unrelated pre-existing issues).

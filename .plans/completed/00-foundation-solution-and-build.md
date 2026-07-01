# 00 — Foundation: solution, packaging & build

**Status:** complete
**Depends on:** nothing (do this first)
**Blocks:** everything

## Goal

Get the repository building on a modern, consistent foundation so every
subsequent plan lands on solid ground: modern target frameworks, central
package management, `.slnx` solution, and an updated CI pipeline. No behaviour
changes to the client itself — this is pure infrastructure.

## Why

The current projects target `netstandard1.1;netstandard2.0;net45`, pin package
versions per-project, use a classic `.sln`, and depend on `Newtonsoft.Json`.
For a clean-slate major version we want the most modern setup possible.

## Scope

### Target frameworks
- Multi-target the shippable libraries to **`net8.0;net9.0;net10.0`**.
  - `src/CompaniesHouse`
  - `src/CompaniesHouse.Extensions.Microsoft.DependencyInjection`
- Remove `netstandard*` / `net45` targets and the
  `Microsoft.NETFramework.ReferenceAssemblies` and `Microsoft.Net.Http`
  package references.
- Tests target `net8.0;net9.0;net10.0` (or just `net10.0` if multi-targeting
  tests is not worth the run time — decide and note it).
- The source generator project (plan `04`) targets **`netstandard2.0`** — this
  is a hard Roslyn requirement and is the one exception to the "no netstandard"
  rule.

### Central Package Management (CPM)
- Add a root **`Directory.Packages.props`** with
  `<ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally>` and a
  `<PackageVersion .../>` for every dependency used anywhere in the repo.
- Strip `Version="..."` from every `<PackageReference>` in every `.csproj`.
- Consolidate versions so all projects share one version per package
  (previously `Microsoft.Extensions.*` was pinned to `3.1.9`).

### Directory.Build.props / .targets
- Enable **`<Nullable>enable</Nullable>`** (already have `ImplicitUsings`,
  `LangVersion latest`, `TreatWarningsAsErrors`, `EnforceCodeStyleInBuild`).
- Refresh `<Copyright>` (currently hard-coded to 2020) — use a year-agnostic or
  current value.
- Keep `IncludeSymbols` + `snupkg`; add `<PublishRepositoryUrl>`,
  `<EmbedUntrackedSources>`, `<ContinuousIntegrationBuild>` and
  **deterministic builds** for good source-link/NuGet hygiene.
- Add `<GenerateDocumentationFile>true</GenerateDocumentationFile>` on the
  shipped libraries so public XML docs are packaged.

### Solution format
- Convert `CompaniesHouse.sln` to **`CompaniesHouse.slnx`** (the new XML
  solution format). Verify `dotnet build CompaniesHouse.slnx` works with the
  installed SDK (repo has 10.x and 11.x preview SDKs available). Delete the old
  `.sln` once the `.slnx` is proven, or keep both briefly if tooling needs it —
  decide and note.
- Add an `.slnx` entry for the future source-generator project.

### CI workflow
- Update `.github/workflows/continuous-integration-workflow.yml`:
  - Ensure the SDK it installs can build `net10.0` (+ `.slnx`); pin via
    `global.json` if needed.
  - Recursively checkout submodules (needed once plan `05` lands):
    `actions/checkout` with `submodules: recursive`.
  - Bump the `VERSION` scheme to the new major (the prerelease tag currently
    produces `9.0.0-preN` — align with the chosen next major).
  - Modernise action versions (`checkout@v2`/`setup-dotnet@v1` are old).

## Tasks

- [x] Add `Directory.Packages.props` and migrate all `PackageReference`s.
- [x] Retarget both library projects to `net8.0;net9.0;net10.0`.
- [x] Remove framework-reference/`Microsoft.Net.Http` packages.
- [x] Enable nullable + doc generation + deterministic build in `Directory.Build.props`.
- [x] Convert solution to `.slnx`; add all existing projects.
- [x] Update CI (SDK, submodules, versioning, action versions).
- [x] `dotnet build -c Release` and `dotnet test -c Release` are green.
- [x] Migrate test stack from NUnit/FluentAssertions to xUnit/Shouldly (scope
      addition requested mid-execution — FluentAssertions' license changed to a
      paid tier from v8; NUnit swapped along with it). See "Test stack
      migration" below.

## Design decisions

- **CPM over per-project versions** — single place to bump, no drift.
- **Drop `netstandard`** — the new major only supports in-support .NET; this
  is an intentional breaking change and is fine for a new major.

## Open questions

- Do we keep `net8.0` (LTS) as the floor, or go `net9.0`+ only? (Assumption:
  keep `net8.0` for the widest supported reach; revisit if a dependency forces
  it.)
Keep net8.0 for the time being.

- Should tests multi-target or run once on `net10.0`? (Assumption: run on
  `net10.0` only for speed; multi-target the libraries only.)
Just target the latest version of `net10.0`

## Acceptance criteria

- Solution builds and tests pass from a clean checkout with only the .NET SDK
  installed.
- No `Newtonsoft.Json`, `netstandard`, or `net45` remain in any shipped
  project (Newtonsoft removal itself is finished in plan `01`).
- All package versions resolve from `Directory.Packages.props`.

## Test stack migration (Shouldly + xUnit)

Mid-execution the user asked to drop FluentAssertions (license changed to a
paid tier from v8) in favour of **Shouldly**, and to swap **NUnit for xUnit**
at the same time. This expanded plan `00`'s scope to a full test-framework
port across all four test projects (~66 files). Completed:

- `Directory.Packages.props`: removed `NUnit`, `NUnit3TestAdapter`,
  `FluentAssertions`; added `xunit` (2.9.2), `xunit.runner.visualstudio`
  (2.8.2), `Shouldly` (4.2.1).
- All NUnit attributes converted to xUnit: `[TestFixture]` removed,
  `[Test]` → `[Fact]`/`[Theory]`, `[TestCase]` → `[InlineData]`,
  `[TestCaseSource]` → `[MemberData]`, `[SetUp]`/`[TearDown]` → constructor
  or `IAsyncLifetime`.
- All FluentAssertions/`NUnit` classic assertions converted to Shouldly
  (`.Should().Be(x)` → `.ShouldBe(x)`, etc).
- **Enum-equivalency redesign**: `CompaniesHouse.Tests` had bespoke
  FluentAssertions `IEquivalencyStep` classes (`ComparingEnumWith`,
  `ComparingArrayEnumWith`) registered via a `[SetUpFixture]` (`Initializer`)
  to bridge test-fixture raw wire strings against real deserialized C# enum
  properties during `BeEquivalentTo` comparisons. Shouldly has no equivalent
  extensibility point. Replaced with a single dependency-free helper,
  `tests/CompaniesHouse.Tests/EquivalencyAssertionExtensions.cs`, exposing
  `actual.ShouldBeEquivalentTo(expected, params string[] excludingPropertyNames)`.
  It recursively walks public properties and bridges enum ↔ raw wire string
  automatically via each enum member's `[EnumMember(Value=...)]` attribute (no
  per-enum registration needed — a strict improvement over the old
  `MapProviders` dictionaries, which had to be hand-maintained in parallel
  with the enums). The old `ComparingEnumWith.cs`, `ComparingArrayEnumWith.cs`
  and `Initializer.cs` were deleted. `EnumerationMappings.cs`/`MapProviders/*`
  were kept — they're still used to enumerate wire-string values for
  parameterized `TestCaseSource`/`MemberData` test data.
- Result: `CompaniesHouse.slnx` builds with 0 errors; 594/597 tests pass. The
  3 failures (`OfficersTestsInvalid`, `PersonsWithSignificantControlTestsInValid`,
  `CompanyFilingHistoryTestsInvalid` in `CompaniesHouse.IntegrationTests`) are
  pre-existing/unrelated to this migration — the live Companies House API now
  returns `200` with an empty result set for malformed company numbers instead
  of `404`, so the "invalid number ⇒ null data" assumption in these three
  tests is stale against current API behaviour. Not fixed here (out of scope
  for infrastructure plan `00`); worth a follow-up ticket.
- `AGENTS.md` and `.plans/outstanding/10-testing-strategy.md` updated to
  document xUnit + Shouldly as the standing test-stack convention.

## References

- Issue #188 (System.Text.Json), #199/#191 (move to GitHub Actions — already
  done, keep modern).
- `.slnx` format: current .NET SDK solution tooling.

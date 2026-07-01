# 11 — Docs, samples & migration guide

**Status:** outstanding
**Depends on:** endpoints as they land; finalise near release
**Blocks:** the v-next release announcement

## Goal

Refresh all consumer-facing documentation for v-next: the README, the runnable
sample, and a clear **migration guide** from the previous major, since v-next is
deliberately breaking.

## Scope

### README
- Rewrite for the new setup:
  - Installation (both packages), supported TFMs (net8/9/10).
  - `CompaniesHouseClient` usage (settings + `HttpClient` construction paths).
  - **DI section** using the new `IOptions<>` overloads and `IConfiguration`
    binding (plan `02`).
  - **Enum/value-type section**: explain string-backed value types, why unknown
    values never throw, `IsKnown`, `Description`, and how to pattern-match
    (link the blog post).
  - Response model: how to read `StatusCode`/`RetryAfter`/`Data` (plan `01`).
  - Per-endpoint usage snippets as endpoints land.
- Fix stale bits: the AppVeyor badge (CI is GitHub Actions now), the 2020
  copyright, and the old base URL / API-key portal links.

### Sample project
- Update `samples/SampleProject` to the new client + DI, demonstrating search,
  company profile, officers, and handling an unknown enum value gracefully.

### Migration guide (`MIGRATION.md` or a README section)
- Enumerate the breaking changes:
  - Target frameworks dropped (`netstandard`/`net45`).
  - `Newtonsoft.Json` → `System.Text.Json` (custom converters replaced).
  - **All enums → string-backed value types** (biggest behavioural change; show
    before/after for a `switch`).
  - `CompaniesHouseClientResponse<T>` shape change (now carries status/headers).
  - Default base URI change (`companieshouse.gov.uk` →
    `company-information.service.gov.uk`).
  - DI API changes (options/overloads); any renamed methods/interfaces.
- Provide copy-paste before/after snippets for the common cases.

### Contributor docs
- Ensure `AGENTS.md` and `.plans/README.md` stay accurate.
- Document the "refresh enumerations" and "release" flows.

## Tasks

- [ ] Rewrite README for v-next (progressive, per-endpoint).
- [ ] Update the sample project.
- [ ] Write the migration guide with before/after snippets.
- [ ] Fix stale badges/links/copyright.
- [ ] Cross-check AGENTS.md + plans are current at release.

## Acceptance criteria

- A new user can install, configure (via DI and directly), and make a search +
  profile call by following the README alone.
- The migration guide covers every breaking change with a before/after example.

## References

- Blog (enum rationale): <https://kevsoft.net/2026/06/28/enums-in-api-contracts.html>
- API reference: <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference>

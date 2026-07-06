# 07 — Endpoint: Company Profile

**Status:** complete
**Depends on:** `01-core`, `03-value-types`; do after `06-search`
**Blocks:** nothing

## Goal

Rebuild the **Company Profile** endpoint from the current documentation.

Docs:
<https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/company-profile/company-profile?v=latest>

`GET /company/{companyNumber}`

## Scope

### Client
- `ICompaniesHouseCompanyProfileClient.GetCompanyProfileAsync(string companyNumber, CancellationToken)`
  hung off `CompaniesHouseClient`.
- Keep the `CompanyProfileUriBuilder` pattern (`company/{escaped-number}`).
- 404 semantics per plan `01` (response with `Data == null`, `StatusCode` set).

### Response model (faithful to docs)
Model the full profile, notably the historically-missing/tricky bits:
- `company_status` / `company_status_detail` / `company_type` / `subtype` /
  `jurisdiction` — **string-backed value types** (plan `03`) — these are the
  exact fields that produced #184/#185/#186/#200/#214.
- `registered_office_address`, `accounts` (incl. `accounting_reference_date`,
  next/last made-up-to, overdue flags), `confirmation_statement`,
  `annual_return`, `sic_codes` (issue #205), `previous_company_names`,
  `foreign_company_details` (issue #217), `links`, `branch_company_details`,
  `date_of_creation`/`date_of_cessation`, `has_charges`, `has_insolvency_history`,
  `has_super_secure_pscs`, `registered_office_is_in_dispute`,
  `undeliverable_registered_office_address`, `can_file`, `is_community_interest_company`.
- Partial/February-style dates and month/year-only fields — use the shared date
  converters (plan `01`).

## Tasks

- [ ] Confirm the full response schema from the docs.
- [ ] Build the response model with value-type enums + `foreign_company_details`
      + `sic_codes`.
- [ ] Wire sub-client + DI registration.
- [ ] Tests: URI builder, deserialization of a real sample payload, integration
      test for a known company number.

## Open questions

- Does `accounting_reference_date` etc. come back as `{day, month}` objects?
  Model as nested types — confirm from docs.

## Acceptance criteria

- A real company profile deserializes fully, including `foreign_company_details`
  and `sic_codes`.
- Unknown `company_status`/`company_type` values do not throw.

## References

- Issues #184/#185/#186 (types/statuses), #200/#214 (breaking data changes),
  #205 (SIC codes), #217 (foreign_company_details), #179 (company address).

## Delivered

- Rebuilt the company-profile enum-ish fields onto the Roslyn-generated
  string-backed value-type pattern: `CompanyStatusDetail` now comes from the
  `company_status_detail` YAML group in the root `CompaniesHouse.Response`
  namespace, `Jurisdiction` now comes from the `jurisdiction` YAML group in
  `CompaniesHouse.Response.CompanyProfile`, and both hand-written wire enums
  were removed. This brings company profile into the same unknown-value-safe
  model already used by `CompanyStatus`/`CompanyType`.
- Added two new generated company-profile value types from the live
  `api-enumerations` data: `ForeignAccountType` and
  `TermsOfAccountPublication`. `foreign_company_details.accounting_requirement`
  now uses these value types directly, so future new wire values round-trip
  without deserialization failures.
- Extended `Response.CompanyProfile.CompanyProfile` to match the confirmed live
  schema gaps: `subtype` (wired to generated `CompanySubtype`),
  `has_super_secure_pscs`, `external_registration_number`, and the full
  `foreign_company_details` object graph. The foreign-company model reuses the
  existing `{day, month}` partial-date shape via `AccountingReferenceDate` for
  `account_period_from` / `account_period_to`, and models
  `must_file_within.months` as the raw string count returned by the API.
- Extended `CompanyProfileLinks` with the missing `exemptions` and
  `uk_establishments` links confirmed by real API payloads.
- Added coverage across the stack: generated value-type round-trip tests for
  `CompanyStatusDetail` and `Jurisdiction`; client-level company-profile tests
  for realistic deserialization plus explicit 404 semantics; scenario
  deserialization tests using captured plain/foreign/CIC payloads; and
  integration assertions for the standard (`00445790`), foreign (`FC040879`)
  and subtype (`13507518`) company profiles.
- Verified: `dotnet build CompaniesHouse.slnx -c Release` with 0 errors;
  `dotnet test tests\CompaniesHouse.Tests\CompaniesHouse.Tests.csproj -c Release`
  passing; `dotnet test tests\CompaniesHouse.ScenarioTests\CompaniesHouse.ScenarioTests.csproj -c Release`
  passing; `dotnet test tests\CompaniesHouse.SourceGenerator.Tests\CompaniesHouse.SourceGenerator.Tests.csproj -c Release`
  passing 28/28 after the enum-map additions; whitespace formatting clean on
  all touched files via `dotnet format whitespace --verify-no-changes`; and the
  targeted company-profile integration tests passing 5/5 with a configured API
  key.

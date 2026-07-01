# 07 — Endpoint: Company Profile

**Status:** outstanding
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

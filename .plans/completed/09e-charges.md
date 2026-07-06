# 09e — Endpoint: Charges

**Status:** complete
**Depends on:** `01-core`, `03-value-types`
**Blocks:** nothing

## Goal

Rebuild company charges list and single-charge endpoints from live payloads and modernise the old wire-enum model.

Docs:
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/charges/list?v=latest>
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/charges/get?v=latest>

Paths:
- `GET /company/{companyNumber}/charges`
- `GET /company/{companyNumber}/charges/{chargeId}`

## Scope

### Client
- `ICompaniesHouseChargesClient` list + single methods.
- Keep `ChargesUriBuilder`.

### Response model
- Envelope fields including `etag`, `unfiltered_count`, `satisfied_count` and `part_satisfied_count`.
- Charge item/detail fields including classification, particulars, secured details, transactions, insolvency cases and links.
- Generated value types for charge status, classification type, particulars type, secured-details type and assets-ceased/released.

## Tasks

- [x] Validate multiple live charge lists and single charges.
- [x] Fix JSON property-name mismatches and nullable gaps.
- [x] Migrate legacy charge wire enums to generated value types.
- [x] Add unit, scenario, generator and integration coverage.

## Open questions

- None after live verification.

## Acceptance criteria

- Charges list and single-charge payloads deserialize from the live API.
- Unknown charge enum-ish values do not throw.

## References

- Existing master implementation to replicate/modernise:
  - `src/CompaniesHouse/CompaniesHouseChargesClient.cs`
  - `src/CompaniesHouse/ICompaniesHouseChargesClient.cs`
  - `src/CompaniesHouse/UriBuilders/ChargesUriBuilder.cs`
  - `src/CompaniesHouse/Response/Charges/Charges.cs`
  - `src/CompaniesHouse/Response/Charges/Charge.cs`

## Delivered

- Verified real charge payloads for `03977902` and `00002065`, including list and single-charge calls.
- Corrected the legacy schema mismatches (`etag`, `unfiltered_count`, nullable nested shapes) and aligned the charge models with the observed API contract.
- Migrated the old charge wire enums to generated string-backed value types using new enum-map entries and overlay YAML inputs.
- Added client/unit tests, URI-builder tests, scenario deserialization coverage, value-type tests and integration assertions for both charge endpoints.

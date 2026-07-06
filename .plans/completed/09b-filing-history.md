# 09b — Endpoint: Filing history

**Status:** complete
**Depends on:** `01-core`, `03-value-types`
**Blocks:** nothing

## Goal

Rebuild filing-history list and single-item endpoints against live Companies House payloads.

Docs:
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/filing-history/list?v=latest>
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/filing-history/filinghistoryitem-resource?v=latest>

Paths:
- `GET /company/{companyNumber}/filing-history`
- `GET /company/{companyNumber}/filing-history/{transactionId}`

## Scope

### Client
- `ICompaniesHouseCompanyFilingHistoryClient` list + single-item methods.
- Keep `CompanyFilingHistoryUriBuilder`.

### Response model
- Full filing-history envelope including paging fields and `links.self`.
- Filing items with `action_date`, `links.document_metadata`, annotations, associated filings and resolutions.
- Replace legacy wire enums with generated string-backed value types for filing category/status/subcategory/resolution category.
- Support `subcategory` arriving as either a single string or an array.

## Tasks

- [x] Validate multiple live companies and single transactions.
- [x] Migrate filing wire enums to generated value types.
- [x] Harden single-or-array subcategory deserialization.
- [x] Add unit, scenario, generator and integration coverage.

## Open questions

- None after live verification.

## Acceptance criteria

- Filing history list and single-item payloads deserialize from real API responses.
- Unknown filing category/subcategory values round-trip without throwing.

## References

- Existing master implementation to replicate/modernise:
  - `src/CompaniesHouse/CompaniesHouseCompanyFilingHistoryClient.cs`
  - `src/CompaniesHouse/ICompaniesHouseCompanyFilingHistoryClient.cs`
  - `src/CompaniesHouse/UriBuilders/CompanyFilingHistoryUriBuilder.cs`
  - `src/CompaniesHouse/Response/CompanyFiling/CompanyFilingHistory.cs`
  - `src/CompaniesHouse/Response/CompanyFiling/FilingHistoryItem.cs`
  - `src/CompaniesHouse/Response/CompanyFiling/FilingHistoryItemAssociatedFiling.cs`
  - `src/CompaniesHouse/Response/CompanyFiling/FilingHistoryItemAnnotation.cs`
  - `src/CompaniesHouse/Response/CompanyFiling/FilingHistoryItemResolution.cs`

## Delivered

- Verified live list and single-item payloads for `00445790`, `00002065` and `SC171417`, including mortgage filings and document links.
- Migrated the old filing-history wire enums onto generated string-backed value types backed by new enum-map entries and generator overlay YAML.
- Updated `EnumArrayOrSingleJsonConverterFactory` so generated value-type arrays can deserialize from either a single string or an array, matching live `subcategory` payloads.
- Added client/unit tests, scenario deserialization coverage, value-type round-trip tests, generator inputs, and real-API integration assertions for list and single-item calls.

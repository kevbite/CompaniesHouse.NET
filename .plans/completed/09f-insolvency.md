# 09f — Endpoint: Insolvency

**Status:** complete
**Depends on:** `01-core`, `03-value-types`
**Blocks:** nothing

## Goal

Modernise the insolvency endpoint against real API responses and move its wire enums onto generated value types.

Docs:
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/insolvency/get?v=latest>

Path:
- `GET /company/{companyNumber}/insolvency`

## Scope

### Client
- `ICompaniesHouseCompanyInsolvencyInformationClient.GetCompanyInsolvencyInformationAsync(...)`.
- Add a dedicated `CompanyInsolvencyInformationUriBuilder`.

### Response model
- `status[]`, `cases[]`, case dates, practitioners, addresses and links.
- Generated value types for insolvency status, case-date type and case type.
- Nullable handling that matches observed live payloads.

## Tasks

- [x] Validate multiple live insolvency payloads.
- [x] Move URI construction into a builder.
- [x] Migrate insolvency wire enums to generated value types.
- [x] Add unit, scenario, generator and integration coverage.

## Open questions

- None after live verification.

## Acceptance criteria

- Insolvency payloads deserialize from real Companies House responses.
- Unknown case/status/date-type values do not throw.

## References

- Existing master implementation to replicate/modernise:
  - `src/CompaniesHouse/CompaniesHouseCompanyInsolvencyInformationClient.cs`
  - `src/CompaniesHouse/ICompaniesHouseCompanyInsolvencyInformationClient.cs`
  - `src/CompaniesHouse/Response/Insolvency/CompanyInsolvencyInformation.cs`
  - `src/CompaniesHouse/Response/Insolvency/Case.cs`
  - `src/CompaniesHouse/Response/Insolvency/CaseDate.cs`
  - `src/CompaniesHouse/Response/Insolvency/Practitioner.cs`
  - `src/CompaniesHouse/Response/Insolvency/Address.cs`
  - `src/CompaniesHouse/Response/Insolvency/Links.cs`

## Delivered

- Verified live insolvency payloads for `08749409` and `07560766` and rebuilt the models around the observed nullable shapes.
- Introduced `ICompanyInsolvencyInformationUriBuilder` / `CompanyInsolvencyInformationUriBuilder` and updated the client to use the shared URI-builder pattern.
- Migrated insolvency status, case-date type and case type from hand-written wire enums/strings to generated string-backed value types.
- Added client/unit tests, URI-builder tests, scenario deserialization coverage, value-type tests and real-API integration assertions.

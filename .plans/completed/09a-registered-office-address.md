# 09a — Endpoint: Registered office address

**Status:** complete
**Depends on:** `01-core`, `07-company-profile`
**Blocks:** nothing

## Goal

Rebuild the registered office address endpoint from the current docs and repeated live payloads.

Docs:
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/registered-office-address/registered-office-address?v=latest>

Path:
- `GET /company/{companyNumber}/registered-office-address`

## Scope

### Client
- `ICompaniesHouseRegisteredOfficeAddressClient.GetRegisteredOfficeAddress(string companyNumber, CancellationToken)` hung off `CompaniesHouseClient` and DI.
- Keep `RegisteredOfficeAddressUriBuilder`.

### Response model
- Faithful address shape with `kind`, `etag`, `links.self` and nullable address lines.
- Preserve live `country` as a raw string, not an enum, because real payloads include values such as `South Africa`.

## Tasks

- [x] Confirm live payloads for UK and foreign companies.
- [x] Remove enum assumptions from `country`.
- [x] Expose the sub-client publicly and register it in DI.
- [x] Add unit, scenario and integration coverage.

## Open questions

- None after live verification.

## Acceptance criteria

- UK and foreign registered-office payloads deserialize without enum failures.
- The sub-client resolves from `CompaniesHouseClient` and DI.

## References

- Existing master implementation to replicate/modernise:
  - `src/CompaniesHouse/CompaniesHouseRegisteredOfficeAddressClient.cs`
  - `src/CompaniesHouse/ICompaniesHouseRegisteredOfficeAddressClient.cs`
  - `src/CompaniesHouse/UriBuilders/RegisteredOfficeAddressUriBuilder.cs`
  - `src/CompaniesHouse/Response/RegisteredOfficeAddress/OfficeAddress.cs`
  - `src/CompaniesHouse/Response/RegisteredOfficeAddress/Links.cs`

## Delivered

- Verified live payloads for `00445790`, `FC040879` and `13507518` and rebuilt the model around the observed nullable contract.
- Replaced the old `OfficeAddressCountry` wire enum with `string?` after confirming real API values are open-ended.
- Made `ICompaniesHouseRegisteredOfficeAddressClient` public, added it to `ICompaniesHouseClient`, and registered it in the DI extension package.
- Added client/unit coverage for captured live JSON, scenario deserialization coverage, DI resolution assertions, and integration assertions against the real API.

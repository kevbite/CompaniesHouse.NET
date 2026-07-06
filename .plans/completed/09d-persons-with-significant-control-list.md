# 09d — Endpoint: Persons with significant control list

**Status:** complete
**Depends on:** `01-core`, `03-value-types`, `07-company-profile`
**Blocks:** `09j-psc-detail-types`

## Goal

Rebuild the existing PSC list endpoint against live payloads and align it with generated value types.

Docs:
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/persons-with-significant-control/list?v=latest>

Path:
- `GET /company/{companyNumber}/persons-with-significant-control`

## Scope

### Client
- `ICompaniesHousePersonsWithSignificantControlClient.GetPersonsWithSignificantControlAsync(...)`.
- Keep `PersonsWithSignificantControlBuilder`.

### Response model
- Full envelope with paging fields, `links.self`, `active_count`, `ceased_count` and `total_results`.
- Items for individuals and corporate entities, including `ceased`, `ceased_on`, identification, links and generated PSC kind/nature-of-control value types.

## Tasks

- [x] Validate companies with different live PSC shapes.
- [x] Migrate PSC kind and nature-of-control wire enums to generated value types.
- [x] Fill the envelope/item schema gaps found in live responses.
- [x] Add unit, scenario, generator and integration coverage.

## Open questions

- PSC statements and detail endpoints remain for `09j`.

## Acceptance criteria

- Live PSC list payloads deserialize for both corporate and individual records.
- Unknown PSC kind/nature values do not throw.

## References

- Existing master implementation to replicate/modernise:
  - `src/CompaniesHouse/CompaniesHousePersonsWithSignificantControlClient.cs`
  - `src/CompaniesHouse/ICompaniesHousePersonsWithSignificantControlClient.cs`
  - `src/CompaniesHouse/UriBuilders/PersonsWithSignificantControlBuilder.cs`
  - `src/CompaniesHouse/Response/PersonsWithSignificantControl/PersonsWithSignificantControl.cs`
  - `src/CompaniesHouse/Response/PersonsWithSignificantControl/PersonWithSignificantControl.cs`
  - `src/CompaniesHouse/Response/PersonsWithSignificantControl/PersonWithSignificantControlIdentification.cs`
  - `src/CompaniesHouse/Response/PersonsWithSignificantControl/PersonWithSignificantControlLinks.cs`

## Delivered

- Verified repeated live PSC list payloads across companies including `03977902`, `03610056`, `09965459`, `06768813` and `07560766`.
- Migrated PSC kind and nature-of-control from hand-written wire enums to generated string-backed value types backed by new enum-map and overlay YAML entries.
- Expanded the list envelope and PSC item models with the missing paging, link, identification and ceased-state fields seen in the real API.
- Added client/unit tests, scenario deserialization coverage, value-type tests and real-API integration assertions for the list endpoint.

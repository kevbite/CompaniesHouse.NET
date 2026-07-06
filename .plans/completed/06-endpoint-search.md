# 06 — Endpoint: Search (start here)

**Status:** complete
**Depends on:** `01-core`, `03-value-types` (for status/type fields)
**Blocks:** nothing; first endpoint to build

## Goal

Build the full **Search** surface — the most-used part of the API — end to end
against the current documentation, using the URI-builder pattern. This is the
first endpoint rebuilt from scratch in v-next and sets the template for the rest.

## Endpoints to cover

From the API reference (verify exact paths/params against the live docs):

| Method on client | Docs page | Path (verify) |
|---|---|---|
| `SearchAllAsync` | search-all | `GET /search` |
| `SearchCompaniesAsync` | search-companies | `GET /search/companies` |
| `SearchOfficersAsync` | search-officers | `GET /search/officers` |
| `SearchDisqualifiedOfficersAsync` | search-disqualified-officers | `GET /search/disqualified-officers` |
| `SearchCompaniesAlphabeticallyAsync` | search-companies-alphabetically | `GET /alphabetical-search/companies` |
| `SearchDissolvedCompaniesAsync` | search-dissolved-companies | `GET /dissolved-search/companies` |
| `AdvancedCompanySearchAsync` | advanced-company-search | `GET /advanced-search/companies` |

Reference docs:
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/search/advanced-company-search?v=latest>
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/search/search-all?v=latest>
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/search/search-companies?v=latest>
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/search/search-officers?v=latest>
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/search/search-disqualified-officers?v=latest>
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/search/search-companies-alphabetically?v=latest>
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/search/search-dissolved-companies?v=latest>

## Scope

### URI builders (keep the pattern)
- Preserve the `SearchUriBuilder`/factory approach: a base builder for the common
  `q` / `items_per_page` / `start_index` query params, with per-search subclasses
  adding their own params.
- **Advanced search** (issue #216 "not implemented", #220 PR) has a rich set of
  filter params (company name includes/excludes, company status, company type,
  company subtype, dissolved-from/to, incorporated-from/to, SIC codes, location,
  size). Model these as a dedicated request with a builder that emits only the
  supplied params.
- **Company search** carries a `restrictions` query param — the old code had a
  bug (`if (string.IsNullOrWhiteSpace(...))` added it only when *empty*). Fix:
  add `restrictions` only when **non**-empty (issues #203/#204/#208).

### Request models
- One request record per search (`SearchAllRequest`, `SearchCompaniesRequest`,
  `AdvancedCompanySearchRequest`, ...). Use the string-backed value types for
  `company_status`/`company_type`/`company_subtype` filters (plan `03`).

### Response models
- Model each response faithfully from the docs: the search envelope
  (`total_results`, `items_per_page`, `start_index`, `page_number`, `kind`,
  `items[]`) plus per-search item shapes.
- **Numbers-as-strings**: SearchAll returned `total_results` etc. as strings —
  handle with `NumberHandling.AllowReadingFromString` or a converter (issue #212).
- Item enum-ish fields (company status/type, officer role, etc.) use value types.
- The old code had a polymorphic `SearchItemConverter` for the "all" search
  (mixed item kinds keyed by `kind`) — reimplement for STJ if `search/all`
  returns heterogeneous items.

### Client wiring
- `ICompaniesHouseSearchClient` (+ granular interfaces if we keep the
  per-search-interface split) hung off `CompaniesHouseClient`. Register in DI
  (plan `02`).

## Tasks

- [ ] Confirm each path + full query-param list from the live docs.
- [ ] Build request models (with value-type filters).
- [ ] Build/extend URI builders per search; fix the `restrictions` bug.
- [ ] Build response envelope + item models from the docs.
- [ ] Handle numbers-as-strings and any polymorphic items.
- [ ] Wire sub-client + DI registrations.
- [ ] Tests: URI-builder unit tests, deserialization scenario tests, one
      integration test per search (plan `10`).

## Open questions

- Do we keep separate `ICompaniesHouseSearchCompanyClient` etc. interfaces, or
  collapse into one `ICompaniesHouseSearchClient` with all methods? (Lean: one
  cohesive search sub-client interface; note the breaking change.)
- Advanced search param names — confirm exact spelling from docs.

## Acceptance criteria

- All 7 searches callable from `CompaniesHouseClient`, returning typed results.
- Unknown status/type values in results don't throw (value types).
- `restrictions` is only sent when provided.

## References

- Issues #203/#204/#208 (restrictions), #212 (numeric strings), #216/#220
  (advanced search), #185/#186 (new company statuses/types in search results).

## Delivered

- Fixed the long-standing `restrictions` query bug in
  `SearchCompanyUriBuilder`: the parameter is now emitted only when a
  non-empty value is supplied, it is URL-escaped consistently with the base `q`
  handling, and `SearchCompanyRequest.Restrictions` is now nullable to reflect
  the documented optional contract.
- Added the three missing Search endpoints to `CompaniesHouseClient` and DI:
  `SearchCompaniesAlphabeticallyAsync` (`GET /alphabetical-search/companies`),
  `SearchDissolvedCompaniesAsync` (`GET /dissolved-search/companies`) and
  `AdvancedCompanySearchAsync` (`GET /advanced-search/companies`), each with a
  dedicated request model, URI builder, response envelope and item models wired
  through the existing `CompaniesHouseSearchClient` / search-builder factory
  pattern.
- Modelled the new endpoint-specific query contracts from the live docs rather
  than forcing them into the older `q/items_per_page/start_index` shape:
  alphabetical search uses `search_above` / `search_below` / `size`,
  dissolved search adds `search_type` plus its paging variants, and advanced
  search emits only the supplied filters, formatting list filters as
  comma-delimited query values and dates as `yyyy-MM-dd`.
- Migrated `CompanyType` from the hand-written wire enum to the Roslyn
  generator by adding `company_type` and `company_subtype` entries to
  `enum-map.txt`, deleting the old `Response/CompanyType.cs`, and consuming the
  generated string-backed `CompanyType` / `CompanySubtype` value types in
  search/company-profile models and advanced-search filters. This keeps unknown
  type/subtype values non-breaking in the same way `CompanyStatus` already is.
- Added unit/integration coverage for the new surface: URI-builder tests for
  the restrictions fix plus the new builders, search-client deserialization
  tests for the 3 new endpoints, value-type round-trip tests for generated
  `CompanyType` / `CompanySubtype`, DI resolution coverage for the new granular
  interfaces, and new real-API integration tests for alphabetical, dissolved
  and advanced company search.
- Verified: full solution build (`CompaniesHouse.slnx`, Release) with 0 errors;
  `CompaniesHouse.Tests` passing; `CompaniesHouse.ScenarioTests` passing;
  `CompaniesHouse.SourceGenerator.Tests` 28/28 after adding a regression test
  for multiple enum-map entries; `CompaniesHouse.Extensions.Microsoft.DependencyInjection.Tests`
  passing; `dotnet format --verify-no-changes` clean on all touched files. The
  full integration suite still has unrelated pre-existing failures in older
  invalid-case tests, but the 3 new search integration tests pass when run
  directly against a configured API key.

# 09l — Endpoint: UK establishments

**Status:** completed
**Depends on:** `01-core`, `07-company-profile`
**Blocks:** nothing

## Goal

Build the UK establishments endpoint from the live API docs.

Docs:
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/uk-establishments/company-uk-establishments?v=latest>

Path:
- `GET /company/{companyNumber}/uk-establishments`

## Scope

- Add a focused UK-establishments sub-client, URI builder and response model.
- Verify the live payload shape, especially address and linkage fields.

## Tasks

- [x] Confirm the docs and live schema.
- [x] Build client, builder and model.
- [x] Add unit, scenario and integration coverage.

## Open questions

- Are UK establishments returned as a simple list or a paged envelope?
  - Answered: live responses are a simple list envelope (`etag`, `kind`, `links`, `items`) without paging fields.

## Acceptance criteria

- A real UK establishments response deserializes from the live API.

## References

- No existing master implementation - build from the live API docs only.
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/uk-establishments/company-uk-establishments?v=latest>

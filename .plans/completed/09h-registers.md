# 09h — Endpoint: Registers

**Status:** completed
**Depends on:** `01-core`
**Blocks:** nothing

## Goal

Build the company registers endpoint from the live API docs.

Docs:
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/registers/company-registers?v=latest>

Path:
- `GET /company/{companyNumber}/registers`

## Scope

- Add a focused registers sub-client, URI builder and response models.
- Verify the live response shape before modelling fields.

## Tasks

- [x] Confirm the live docs and payload shape.
- [x] Build client, URI builder and response model.
- [x] Add unit, scenario and integration coverage.

## Open questions

- Which registers fields are actually present in live payloads, and are they link-only or richer nested objects?
  - Answered: live payloads can be sparse and omit several fields marked required in the spec (for example, `company_number`, some register sections, and `links` inside register items).

## Acceptance criteria

- A real registers response deserializes cleanly from the live API.

## References

- No existing master implementation - build from the live API docs only.
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/registers/company-registers?v=latest>

# 09k — Endpoint: Exemptions

**Status:** completed
**Depends on:** `01-core`, `03-value-types`
**Blocks:** nothing

## Goal

Build the company exemptions endpoint from the live API docs.

Docs:
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/exemptions/get?v=latest>

Path:
- `GET /company/{companyNumber}/exemptions`

## Scope

- Add a focused exemptions sub-client, URI builder and response model.
- Decide whether any exemption-description values should come from generated string-backed value types.

## Tasks

- [x] Confirm the live docs and payload schema.
- [x] Build client, builder and response model.
- [x] Add unit, scenario and integration coverage.

## Open questions

- Which exemption-description group in `api-enumerations` should back any enum-ish fields?
  - Answered for now: no generated exemption-specific value type exists in this repo yet, so exemption type fields are modelled as raw strings and preserve wire values.

## Acceptance criteria

- A real exemptions response deserializes cleanly from the live API.

## References

- No existing master implementation - build from the live API docs only.
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/exemptions/get?v=latest>

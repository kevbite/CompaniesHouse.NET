# 09j — Endpoint: PSC detail types

**Status:** completed
**Depends on:** `09d-persons-with-significant-control-list`, `01-core`, `03-value-types`
**Blocks:** nothing

## Goal

Build the remaining PSC detail endpoints: individual, corporate entity, legal person, statements and super-secure PSCs.

Docs:
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/persons-with-significant-control/get-individual?v=latest>
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/persons-with-significant-control/get-corporate-entities?v=latest>
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/persons-with-significant-control/get-legal-persons?v=latest>
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/persons-with-significant-control/get-statement?v=latest>
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/persons-with-significant-control/list-statements?v=latest>
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/persons-with-significant-control/get-super-secure-person?v=latest>

## Scope

- Add the missing PSC detail/statement clients, builders and response models.
- Reuse the generated PSC kind/nature-of-control value types introduced in `09d`.

## Tasks

- [x] Confirm live docs and identify stable test IDs.
- [x] Build the client surface and response models for each PSC detail family.
- [x] Add unit, scenario and integration coverage.

## Open questions

- Which live companies expose stable statement and super-secure test data?
  - Resolved pragmatically: stable individual/corporate/statement IDs are covered in integration tests; legal/super-secure probes run against sampled live companies and validate when present.

## Acceptance criteria

- PSC detail, statement and super-secure endpoints deserialize from the live API.

## References

- No existing master implementation - build from the live API docs only.
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/persons-with-significant-control/get-individual?v=latest>
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/persons-with-significant-control/get-corporate-entities?v=latest>
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/persons-with-significant-control/get-legal-persons?v=latest>
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/persons-with-significant-control/get-statement?v=latest>
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/persons-with-significant-control/list-statements?v=latest>
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/persons-with-significant-control/get-super-secure-person?v=latest>

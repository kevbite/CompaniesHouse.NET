# 09i — Endpoint: Disqualified officers detail

**Status:** completed
**Depends on:** `01-core`, `06-search`
**Blocks:** nothing

## Goal

Build the natural-person and corporate disqualified-officer detail endpoints from the live API docs.

Docs:
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/officer-disqualifications/get-natural-officer?v=latest>
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/officer-disqualifications/get-corporate-officer?v=latest>

Paths:
- `GET /disqualified-officers/natural/{officerId}`
- `GET /disqualified-officers/corporate/{officerId}`

## Scope

- Add a focused sub-client, URI builders and response models for natural and corporate detail payloads.
- Reuse generated value types where the live schema exposes enum-ish fields.

## Tasks

- [x] Confirm live docs and payload examples.
- [x] Build the client, builders and models.
- [x] Add unit, scenario and integration coverage.

## Open questions

- Are the natural and corporate payloads structurally distinct enough to justify separate response types?
  - Answered: yes; they share common nested shapes but differ in top-level identity fields (`surname`/name parts vs `name`, optional registration metadata), so separate top-level response types are clearer.

## Acceptance criteria

- Both disqualified-officer detail endpoints deserialize from the live API.

## References

- No existing master implementation - build from the live API docs only.
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/officer-disqualifications/get-natural-officer?v=latest>
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/officer-disqualifications/get-corporate-officer?v=latest>

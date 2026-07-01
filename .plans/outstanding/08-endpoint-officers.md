# 08 — Endpoint: Officers

**Status:** outstanding
**Depends on:** `01-core`, `03-value-types`; do after `07-company-profile`
**Blocks:** nothing

## Goal

Rebuild the **Officers** endpoints from the current documentation.

Docs:
- List: <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/officers/list?v=latest>
- Get appointment: <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/officers/get-a-company-officer-appointment?v=latest>

Paths (verify):
- `GET /company/{companyNumber}/officers`
- `GET /company/{companyNumber}/appointments/{appointmentId}`

## Scope

### Client
- `ICompaniesHouseOfficersClient`:
  - `GetOfficersAsync(companyNumber, startIndex = 0, pageSize = 35, ..., CancellationToken)`
  - `GetOfficerAppointmentAsync(companyNumber, appointmentId, CancellationToken)`
- Keep `OfficersUriBuilder` / `OfficersAppointmentUriBuilder` patterns.
- The list endpoint supports `register_view`, `order_by`, `items_per_page`,
  `start_index` — confirm and expose the useful ones.

### Response models (faithful to docs)
- List envelope: `total_results`, `items_per_page`, `start_index`,
  `active_count`, `inactive_count`, `resigned_count`, `kind`, `links`, `items[]`.
  - Ensure `total_results` is present and typed `int` (issues #206/#207).
- Officer item / appointment:
  - `officer_role` — **string-backed value type** (issues #197/#198:
    `managing-officer` and other new roles kept breaking the old enum).
  - `person_number` (issues #221/#222 — was missing).
  - `address`, `date_of_birth` (month/year only — partial-date converter),
    `appointed_on`, `resigned_on`, `nationality`, `occupation`,
    `country_of_residence`, `identification` (+ `identification_type` value
    type), `former_names`, `links.officer.appointments`,
    `contact_details`, `principal_office_address`,
    `responsibilities`/`is_pre_1992_appointment` where present.
- Provide the computed `OfficerId` convenience the community relied on (issues
  #169/#171 — it was deleted then restored). Derive from the appointments link.

## Tasks

- [ ] Confirm list + appointment schemas and query params from docs.
- [ ] Build response models with value-type `officer_role`/`identification_type`
      and `person_number`, `total_results:int`.
- [ ] Restore the `OfficerId` computed property.
- [ ] Wire sub-client + DI registrations.
- [ ] Tests: URI builders, deserialization of sample payloads (incl. an unknown
      officer role), integration tests.

## Open questions

- Default page size: API default is 35 for officers — match it rather than the
  old 25. Confirm.

## Acceptance criteria

- Officer list and single appointment deserialize fully, including
  `person_number` and `total_results`.
- An unknown `officer_role` does not throw.
- `OfficerId` is available on items.

## References

- Issues #197/#198 (officer roles), #206/#207 (total_results),
  #221/#222 (person_number), #169/#171 (OfficerId), #165/#166 (get appointment).

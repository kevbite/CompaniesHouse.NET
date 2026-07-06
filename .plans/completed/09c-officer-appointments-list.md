# 09c — Endpoint: Officer appointments list

**Status:** complete
**Depends on:** `01-core`, `03-value-types`, `08-officers`
**Blocks:** nothing

## Goal

Modernise the officer appointments list endpoint and verify it against live natural-person and corporate-officer payloads.

Docs:
- <https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference/officer-appointments/list?v=latest>

Path:
- `GET /officers/{officerId}/appointments`

## Scope

### Client
- `ICompaniesHouseAppointmentsClient.GetAppointmentsAsync(...)` hung off `CompaniesHouseClient`.
- Add a dedicated `AppointmentsUriBuilder` rather than inlined string concatenation.

### Response model
- Envelope counts, paging fields, `kind`, `name`, `links.self`, `is_corporate_officer` and `date_of_birth`.
- Appointment items with `links.company`, `identification`, `is_pre_1992_appointment` and generated `CompanyStatus` / `OfficerRole` values.

## Tasks

- [x] Validate live natural-person and corporate-officer appointment lists.
- [x] Move URI construction into a dedicated builder.
- [x] Expand the response envelope and item models to match live payloads.
- [x] Add unit, scenario and integration coverage.

## Open questions

- None after live verification.

## Acceptance criteria

- Natural and corporate appointment lists deserialize fully from the live API.
- URI construction follows the standard builder pattern.

## References

- Existing master implementation to replicate/modernise:
  - `src/CompaniesHouse/CompaniesHouseAppointmentsClient.cs`
  - `src/CompaniesHouse/ICompaniesHouseAppointmentsClient.cs`
  - `src/CompaniesHouse/Response/Appointments/Appointments.cs`
  - `src/CompaniesHouse/Response/Appointments/Appointment.cs`

## Delivered

- Verified real officer appointment payloads for `uQNQ-blSo-8PiOaehWClTPmbZNI` and `YwIOmduyS6PW5axJgQQrsTGyRD0`.
- Introduced `IAppointmentsUriBuilder` / `AppointmentsUriBuilder` and updated the client to use the shared URI-builder pattern.
- Expanded the appointments envelope and item models with the observed counts, links, identification and corporate-officer fields.
- Added dedicated client/unit tests, URI-builder tests, scenario deserialization coverage and integration assertions for both officer shapes.

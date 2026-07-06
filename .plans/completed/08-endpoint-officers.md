# 08 — Endpoint: Officers

**Status:** complete
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

## Delivered

- Rebuilt the officers wire enums onto the Roslyn-generated string-backed value
  type pattern. `OfficerRole` now comes from the `officer_role` YAML group and
  `OfficerIdentification.IdentificationType` now uses a generated
  `IdentificationType` value type from the `identification_type` YAML group,
  replacing the old hand-written enum/string model and preserving unknown future
  wire values without deserialization failures.
- Extended the officers response models to match the confirmed live schema:
  list envelopes now include `etag`, `kind`, `links.self`, `inactive_count` and
  `items_per_page`; officer/appointment items now include `etag`,
  `person_number`, `is_pre_1992_appointment`, `identity_verification_details`,
  `links.self`, and the live `appointed_before` field seen on historic
  appointments. `total_results` remains a non-nullable `int`, matching repeated
  real API responses.
- Restored the `OfficerId` convenience on `Response.Officers.Officer` as a
  computed, `[JsonIgnore]`d property derived from
  `links.officer.appointments`, and hardened the shared parsing logic so missing
  or malformed links return `null` rather than throwing.
- Extended `GetOfficersAsync` and `OfficersUriBuilder` with the documented
  optional query parameters `register_type`, `register_view` and `order_by`,
  while keeping the established "only emit supplied optional parameters"
  builder pattern. The officers endpoint default page size is now 35 instead of
  25 to match Companies House's documented behaviour.
- Added coverage across the stack: URI-builder tests for the new query
  parameters; client/unit tests using captured live list + appointment payloads;
  new value-type round-trip tests for `OfficerRole` and `IdentificationType`;
  scenario deserialization tests for the confirmed Tesco and Informa samples;
  and live integration assertions for `00445790` and `03610056`, including the
  identity-verification and corporate-identification shapes.
- Verified: `dotnet build CompaniesHouse.slnx -c Release` with 0 errors;
  `dotnet test tests\CompaniesHouse.Tests\CompaniesHouse.Tests.csproj -c Release`
  passing; `dotnet test tests\CompaniesHouse.ScenarioTests\CompaniesHouse.ScenarioTests.csproj -c Release`
  passing; `dotnet test tests\CompaniesHouse.SourceGenerator.Tests\CompaniesHouse.SourceGenerator.Tests.csproj -c Release`
  passing 28/28 after the enum-map additions; `dotnet test tests\CompaniesHouse.Extensions.Microsoft.DependencyInjection.Tests\CompaniesHouse.Extensions.Microsoft.DependencyInjection.Tests.csproj -c Release`
  passing; whitespace formatting clean on all touched files via
  `dotnet format whitespace --verify-no-changes`; the new officers integration
  tests passing 3/3 against the real API; and repeated live
  `CompaniesHouseClient.GetOfficersAsync` / `GetOfficerByAppointmentIdAsync`
  calls deserializing the confirmed payloads without throwing.

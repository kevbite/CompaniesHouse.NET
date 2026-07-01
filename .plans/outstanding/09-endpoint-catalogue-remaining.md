# 09 — Endpoint catalogue: the remaining API surface

**Status:** outstanding
**Depends on:** `01-core`, `03-value-types`; do after `08-officers`
**Blocks:** nothing

## Goal

Track and rebuild **every remaining endpoint** of the Companies House Public
Data API, one at a time, following the pattern established by plans `06`–`08`.
When picking up an endpoint from this catalogue, **split it into its own plan
file** (`09a-...`, `09b-...`, or a dedicated number) rather than doing it inline
here.

Reference index:
<https://developer-specs.company-information.service.gov.uk/companies-house-public-data-api/reference>

## Catalogue (rebuild in roughly this order)

Grouped by API tag. Confirm exact paths/params/schemas from the docs at
implementation time.

### Registered office & registers
- [ ] **Registered office address** — `GET /company/{n}/registered-office-address`
      (issues #163/#164, #179).
- [ ] **Registers** — `GET /company/{n}/registers`.

### Filing history
- [ ] **Filing history list** — `GET /company/{n}/filing-history`.
- [ ] **Single filing** — `GET /company/{n}/filing-history/{transactionId}`.
      Category/subcategory are the enum-heavy fields that caused #168 (`debenture`),
      #209/#210, #218/#219 (`investment-company`) — use value types + the
      `filing_history_descriptions.yml` generator data. Note subcategory can be
      an array in some payloads (old `FilingSubcategoryConverter`).

### Officers (related)
- [ ] **Company officer disqualifications (natural)** —
      `GET /disqualified-officers/natural/{officerId}`.
- [ ] **Corporate officer disqualifications** —
      `GET /disqualified-officers/corporate/{officerId}`.
- [ ] **Officer appointments list** — `GET /officers/{officerId}/appointments`
      (the current `GetAppointmentsAsync`).

### Persons with significant control (PSC)
- [ ] **PSC list** — `GET /company/{n}/persons-with-significant-control`.
- [ ] **Individual PSC** — `.../individual/{id}`.
- [ ] **Corporate entity PSC** — `.../corporate-entity/{id}`.
- [ ] **Legal person PSC** — `.../legal-person/{id}`.
- [ ] **PSC statements** — `.../statements` and `.../statements/{id}`.
- [ ] **Super-secure PSC** — `.../super-secure/{id}`.
      PSC kinds/natures-of-control are enum-heavy (issues #200/#201/#211/#214);
      use value types + `psc_descriptions.yml`. Ensure `total_results`
      (issue #211) and `identification` (issue #173/#155) are modelled.

### Charges
- [ ] **Charges list** — `GET /company/{n}/charges`.
- [ ] **Single charge** — `GET /company/{n}/charges/{chargeId}`.
      Status/classification/particulars are enum-heavy — value types.

### Insolvency & exemptions
- [ ] **Insolvency** — `GET /company/{n}/insolvency`.
- [ ] **Exemptions** — `GET /company/{n}/exemptions`
      (uses `exemption_descriptions.yml`).

### UK establishments
- [ ] **UK establishments** — `GET /company/{n}/uk-establishments`.

### Documents (separate Document API host)
- [ ] **Document metadata** — Document API `GET /document/{id}`.
- [ ] **Download document** — `GET /document/{id}/content` (binary; keep the
      separate base URI + document sub-client, and the DI document options).

## Per-endpoint checklist (apply to each)

- [ ] Confirm path, query params, and response schema from the live docs.
- [ ] Request model (if any) + URI builder following the established pattern.
- [ ] Response model faithful to docs; all enum-ish fields use value types.
- [ ] Sub-client interface hung off `CompaniesHouseClient` + DI registration.
- [ ] Tests: URI builder, deserialization scenario, integration.
- [ ] Move the split-out plan to `completed/` when done.

## Open questions

- Which endpoints are in-scope for the first v-next release vs a later minor?
  (Lean: search + company profile + officers + registered office + filing
  history + PSC + charges for the first stable; documents/exemptions/registers
  can follow.)

## References

- Full reference index (above). Enum data in `api-enumerations` (plan `05`).
- Issues: #163/#164/#179, #168/#209/#210/#218/#219 (filing categories),
  #155/#173/#200/#201/#211/#214 (PSC), #205 (SIC), #180 (sandbox).

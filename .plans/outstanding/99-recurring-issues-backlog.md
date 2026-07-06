# 99 — Recurring issues backlog (design validation)

**Status:** outstanding (keep open as a checklist)
**Purpose:** a living record of the real-world pain points the v-next design must
eliminate. Validate each plan against this list; tick items off as the design
provably handles them.

## The dominant class: new enum values break deserialization

By far the most common bug report. Every one of these is "Companies House
returned a string my client's enum didn't know about, and it threw."

- #168 — `ArgumentException: Requested value 'debenture'` (filing subcategory)
- #185 / #186 — new company statuses & types
- #184 — company type `registered-overseas-entity`
- #197 / #198 — officer role `managing-officer` and other new roles
- #200 / #201 — PSC deserialization / missing enum values
- #209 / #210 — new filing category/subcategory values
- #218 / #219 — filing subcategory `investment-company`

**Design answer:** string-backed value types (plan `03`) + source generator from
`api-enumerations` (plans `04`/`05`). Unknown values **never throw** and the raw
string is preserved. ✅ when: a scenario test deserializes an unknown value for
every enum-ish field without throwing.

## Second class: missing / mistyped fields on responses

- #205 — SIC codes
- #206 / #207 — `total_results` missing on officers
- #211 — `total_results` missing on PSC
- #212 — SearchAll `total_results`/`items_per_page`/`start_index` typed as
  string, should be int
- #217 — `foreign_company_details` missing on company profile
- #221 / #222 — `person_number` missing on officers
- #155 / #173 — PSC `identification`
- #179 — company address
- #214 — PSC breaking data changes

**Design answer:** rebuild every response model faithfully from the current docs
(plans `06`–`09`), with `NumberHandling.AllowReadingFromString` for CH's
string-numbers (plan `01`). ✅ when: each endpoint's model is doc-complete and
has a deserialization test over a real payload.

## Third class: raw value / observability

- #156 — consumers want the raw string, not a mapped/swallowed value

**Design answer:** value types keep `.Value` (the raw string) always. ✅ when:
`.Value` returns the exact wire string for unknown values.

## Response & error ergonomics

- #181 / #182 — include StatusCode, ReasonPhrase, RetryAfter on failures
- #189 — redesign `CompaniesHouseClientResponse`
- #202 — auth discrepancies

**Design answer:** redesigned response wrapper carrying transport metadata
(plan `01`). ✅ when: a 429 surfaces `RetryAfter`; non-2xx surfaces status/headers.

## Serialization & dependencies

- #188 — move to `System.Text.Json`
- #176 / #177 / #178 / #195 / #196 — endless Newtonsoft.Json version bumps

**Design answer:** STJ everywhere, Newtonsoft removed entirely (plans `00`/`01`).
✅ when: no `Newtonsoft.Json` reference anywhere in the repo.

## DI / configuration

- #190 / #193 — use `services.TryAdd*` (done — preserve)
- #192 / #194 — pull the API key from any location
- (v-next) move to `IOptions<>` with config binding + validation

**Design answer:** `IApiKeyProvider` abstraction + `IOptions<>` pipeline
(plan `02`). ✅ when: a custom `IApiKeyProvider` can be registered and the key
can be bound from `IConfiguration`.

## Feature gaps

- #216 / #220 — advanced search not implemented → now first-class (plan `06`)
- #165 / #166 — get individual officer appointment (plan `08`)
- #163 / #164 — registered office address (plan `09`)
- #180 — sandbox/test API support (configurable base URI — plans `01`/`02`)
- #213 / #215 — optional date formatting on descriptable types
- #169 / #171 — keep the `OfficerId` computed property (plan `08`)

## How to use this file

When closing out a plan, re-read the relevant class above and confirm the design
demonstrably handles it (ideally with a test named after the issue). This file
is the "have we actually fixed the recurring pain?" gate for the release.

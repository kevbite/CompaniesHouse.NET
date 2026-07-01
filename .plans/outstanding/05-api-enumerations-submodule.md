# 05 — api-enumerations submodule & local extras

**Status:** outstanding
**Depends on:** `00-foundation` (CI submodule checkout)
**Blocks:** `04-enum-source-generator` (provides its input)

## Goal

Pull the Companies House `api-enumerations` data into the repo as a **git
submodule** and establish a repo-local "extras" area, so the source generator
(plan `04`) has a versioned, updatable source of enum values plus a place for our
own additions.

## Why

The enum values must come from an authoritative, refreshable source rather than
being copied into the repo by hand. A submodule pins an exact commit (reproducible
builds) while making updates a one-liner. We also need a way to add values CH
hasn't published yet, so we keep a local overlay.

## Scope

### Submodule
- Add `https://github.com/companieshouse/api-enumerations` as a submodule at a
  stable path, e.g. `external/api-enumerations`.
  ```
  git submodule add https://github.com/companieshouse/api-enumerations external/api-enumerations
  ```
- Pin to a known-good commit; document the update procedure:
  ```
  git submodule update --remote external/api-enumerations
  ```
- Ensure CI checks out submodules recursively (coordinated in plan `00`:
  `actions/checkout` with `submodules: recursive`). The `Dockerfile` build path
  must also receive the submodule content (copy it into the build context).

### Local extras overlay
- Create `enumerations/extra/` in this repo for our own YAML lists in the same
  `key: {'value': "Description"}` format. Two uses:
  1. **Overrides/additions** to existing groups (values CH is late publishing).
  2. **Library-only groups** not present upstream.
- Document the merge rule (submodule first, extras override/append) — consumed
  by plan `04`.

### Consumption
- The generator reads YAML from **both** `external/api-enumerations/*.yml` and
  `enumerations/extra/*.yml` via `AdditionalFiles` globs in the generator/host
  project.

## Tasks

- [ ] Add the submodule at `external/api-enumerations` and pin a commit.
- [ ] Add `.gitmodules`; verify a fresh `git clone --recursive` populates it.
- [ ] Create `enumerations/extra/` with a README describing the format + merge
      rules and a small example file.
- [ ] Ensure CI and the Dockerfile build include submodule content.
- [ ] Document the "how to refresh enumerations" steps (in the extras README or
      AGENTS.md).

## Design decisions

- **Submodule over vendoring/copy** — pins an exact upstream commit, trivially
  updatable, keeps provenance clear.
- **Local overlay** — lets us out-run CH's publishing cadence without forking.

## Open questions

- Submodule path: `external/api-enumerations` vs `lib/` vs `third_party/`.
  (Lean: `external/`.)
- Auto-update cadence: a scheduled CI job that bumps the submodule and opens a
  PR? (Nice-to-have; note as a follow-up, not required for v-next.)

## Acceptance criteria

- Fresh `git clone --recursive` yields the YAML files on disk.
- CI builds have the submodule content available to the generator.
- Adding a file under `enumerations/extra/` is picked up by the generator
  (verified once plan `04` lands).

## References

- Enumerations repo: <https://github.com/companieshouse/api-enumerations>
- Files seen: `constants.yml`, `filing_history_descriptions.yml`,
  `mortgage_descriptions.yml`, `psc_descriptions.yml`, `officer_filing.yml`,
  `disqualified_officer_descriptions.yml`, `exemption_descriptions.yml`, etc.

# `enumerations/extra/`

This folder is a repo-local overlay on top of the
[`companieshouse/api-enumerations`](https://github.com/companieshouse/api-enumerations)
git submodule at `external/api-enumerations/`. It lets us:

1. **Add values Companies House haven't published yet** (or have used in the
   live API before updating their own reference data).
2. **Define library-only enum groups** that don't exist upstream at all.

The source generator (plan `04`) reads YAML from **both** locations and merges
them per top-level group key:

- The submodule (`external/api-enumerations/*.yml`) is read first.
- Files in this folder (`enumerations/extra/*.yml`) are read second and merged
  **on top**: for a given group (e.g. `company_status`), any wire-value key
  present in an extras file **overrides** the submodule's entry for that key;
  keys not present in the submodule are **appended**.
- You may add entirely new group keys here that don't exist upstream at all —
  they behave like any other generated group.

## File format

Same shape as the upstream files — a YAML mapping of group name to a mapping
of wire value to human-readable description:

```yaml
group_name:
    'wire-value' : "Friendly description"
```

## Example

`company_status.yml` in this folder adds the description for `closed-on`,
which the upstream `constants.yml` `company_status` group is missing (all
other `company_status` entries continue to come from the submodule):

```yaml
company_status:
    'closed-on' : "Closed On"
```

## Refreshing the upstream submodule

```powershell
git submodule update --remote external/api-enumerations
git add external/api-enumerations
git commit -m "Bump api-enumerations submodule"
```

A scheduled workflow (`.github/workflows/bump-api-enumerations.yml`) does this
automatically once a month and opens a pull request for review — new upstream
values still only take effect once that PR is merged and the package is
rebuilt (see plan `04`: generation happens at build time in this repo, not in
consumers).

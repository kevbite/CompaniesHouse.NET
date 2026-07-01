# .plans

The work breakdown for the **CompaniesHouse.NET v-next** major rewrite (on the
`prerelease` branch).

## How this folder works

- **`outstanding/`** — plans not yet completed. Each file is a self-contained,
  refinable unit of work. Numeric prefixes suggest ordering (lower first).
- **`completed/`** — plans that have been fully delivered and verified. When you
  finish a plan, **move its file here** in the same change.

Plans are **living documents**. Refine tasks, record decisions, and capture
open questions as you learn. A plan is "done" only when its acceptance criteria
are met and its code is merged to `prerelease`.

## Plan index (outstanding)

| # | Plan | Theme |
|---|------|-------|
| 00 | `00-foundation-solution-and-build.md` | `.slnx`, central packages, multi-target net8/9/10, drop Newtonsoft, CI |
| 01 | `01-core-client-architecture.md` | `CompaniesHouseClient` entry point, sub-client pattern, `System.Text.Json`, response/error model |
| 02 | `02-di-extensions-ioptions.md` | Modern DI with `IOptions<>` / `AddOptions` / config binding |
| 03 | `03-string-backed-value-types.md` | Replace all enums with string-backed `readonly record struct`s |
| 04 | `04-enum-source-generator.md` | Roslyn generator that emits the value types |
| 05 | `05-api-enumerations-submodule.md` | `api-enumerations` git submodule + local "extra" lists |
| 06 | `06-endpoint-search.md` | All 7 search endpoints (incl. advanced search) — **start here for endpoints** |
| 07 | `07-endpoint-company-profile.md` | Company profile |
| 08 | `08-endpoint-officers.md` | Officer list + get appointment |
| 09 | `09-endpoint-catalogue-remaining.md` | Every other endpoint, to be split into its own plan when picked up |
| 10 | `10-testing-strategy.md` | Unit / scenario / integration / generator tests |
| 11 | `11-docs-samples-migration.md` | README, samples, v-old → v-next migration guide |
| 99 | `99-recurring-issues-backlog.md` | Historical pain points the design must eliminate |

## Suggested execution order

1. **Foundation** (`00`) — get the solution building on modern targets first.
2. **Core + DI + enums** (`01`, `02`, `03`, `04`, `05`) — the plumbing every
   endpoint depends on. `03`/`04`/`05` can proceed in parallel with `01`.
3. **Endpoints, one at a time** (`06` → `07` → `08` → `09`), starting with
   search. Each endpoint should be shippable on its own.
4. **Testing and docs** (`10`, `11`) run continuously alongside the endpoints.

Keep `99` open as a checklist to validate the design against real-world bugs.

# 09g — Endpoint: Documents

**Status:** complete
**Depends on:** `01-core`
**Blocks:** nothing

## Goal

Verify the Document API metadata and download endpoints, including the separate host and content-download behavior.

Docs:
- <https://developer.company-information.service.gov.uk/api/docs/document/documentId/metadata/getDocumentMetadata.html>
- <https://developer.company-information.service.gov.uk/api/docs/document/documentId/document/getDocument.html>

Paths:
- `GET /document/{documentId}` (metadata, via the document API host)
- `GET /document/{documentId}/content`

## Scope

### Client
- `ICompaniesHouseDocumentMetadataClient` and `ICompaniesHouseDocumentDownloadClient` exposed through `ICompaniesHouseDocumentClient` / `CompaniesHouseClient`.
- Keep dedicated metadata/content URI builders.

### Response model
- Metadata with `filename`, `created_at`, nullable `significant_date`, `links`, and resource content lengths large enough for real files.
- Download handling that preserves content headers and stream length.

## Tasks

- [x] Validate real metadata responses and at least one live content download.
- [x] Fix metadata field types and nullability based on the real API.
- [x] Add unit, scenario and integration coverage.
- [x] Verify URI/host construction for the separate document API host.

## Open questions

- None after live verification.

## Acceptance criteria

- Document metadata and download calls succeed against the live API.
- Metadata fields match the observed real payload types.

## References

- Existing master implementation to replicate/modernise:
  - `src/CompaniesHouse/CompaniesHouseDocumentClient.cs`
  - `src/CompaniesHouse/CompaniesHouseDocumentMetadataClient.cs`
  - `src/CompaniesHouse/CompaniesHouseDocumentDownloadClient.cs`
  - `src/CompaniesHouse/ICompaniesHouseDocumentClient.cs`
  - `src/CompaniesHouse/ICompaniesHouseDocumentMetadataClient.cs`
  - `src/CompaniesHouse/ICompaniesHouseDocumentDownloadClient.cs`
  - `src/CompaniesHouse/UriBuilders/DocumentMetadataUriBuilder.cs`
  - `src/CompaniesHouse/UriBuilders/DocumentContentUriBuilder.cs`
  - `src/CompaniesHouse/Response/Document/DocumentMetadata.cs`
  - `src/CompaniesHouse/Response/Document/DocumentDownload.cs`

## Delivered

- Verified live metadata responses for filing-history documents and confirmed live content download behavior against the document API host.
- Updated document metadata types to match real payloads: `CreatedAt` and `SignificantDate` are typed dates, `Filename` is modelled explicitly, and resource content lengths now support large values.
- Added URI-builder tests, client/unit tests, scenario deserialization coverage and live integration assertions for both metadata and content download.
- Confirmed that document download succeeds without forcing an `Accept: application/json` header, which the live endpoint rejects with `406`.

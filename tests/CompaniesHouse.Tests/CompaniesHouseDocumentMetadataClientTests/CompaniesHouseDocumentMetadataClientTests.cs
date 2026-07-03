using System;
using System.Collections.Generic;
using System.Net.Http;
using CompaniesHouse.Response.Document;
using CompaniesHouse.UriBuilders;
using Moq;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.CompaniesHouseDocumentMetadataClientTests
{
    public class CompaniesHouseDocumentMetadataClientTests
    {
        private const string DocumentId = "wibble";
        private DocumentMetadataTestCase _expected;
        private CompaniesHouseResponse<DocumentMetadata> _result;

        public CompaniesHouseDocumentMetadataClientTests()
        {
            _expected = SetupExpectedDocumentMetadata();
            var requestUri = new Uri($"https://document-api.companieshouse.gov.uk/document/{DocumentId}");
            var stubHttpMessageHandler = SetupApiResponse(_expected, requestUri);
            var mockUriBuilder = SetupRequestUri(requestUri);

            _result = new CompaniesHouseDocumentMetadataClient(new HttpClient(stubHttpMessageHandler), mockUriBuilder.Object)
                .GetDocumentMetadataAsync(DocumentId).Result;
        }

        [Fact]
        public void ThenDocumentMetadataIsCorrect()
        {
            EquivalencyAssertionExtensions.ShouldBeEquivalentTo((object)_result.Data, _expected, nameof(DocumentMetadata.CreatedAt));
            _result.Data.CreatedAt.ShouldBe(_expected.CreatedAt);
        }

        [Fact]
        public async Task GivenARealCapturedDocumentMetadata_WhenGettingDocumentMetadata_ThenFilenameAndContentLengthDeserialize()
        {
            const string documentId = "IHFGB_pcm7rSIRefsfuXK1MDkLFxrSoHbKKAgY7OTxk";
            const string json = """
                {
                  "company_number":"00445790",
                  "barcode":"XF5EZFHE",
                  "significant_date":null,
                  "significant_date_type":"",
                  "category":"annual-returns",
                  "pages":3,
                  "filename":"00445790_cs01_2026-07-01",
                  "created_at":"2026-07-01T08:28:44.698561376Z",
                  "etag":"",
                  "links":{"self":"https://document-api.company-information.service.gov.uk/document/IHFGB_pcm7rSIRefsfuXK1MDkLFxrSoHbKKAgY7OTxk","document":"https://document-api.company-information.service.gov.uk/document/IHFGB_pcm7rSIRefsfuXK1MDkLFxrSoHbKKAgY7OTxk/content"},
                  "resources":{"application/pdf":{"content_length":82803}}
                }
                """;

            var requestUri = new Uri($"https://document-api.company-information.service.gov.uk/document/{documentId}");
            var stubHttpMessageHandler = new StubHttpMessageHandler(requestUri, json);
            var mockUriBuilder = new Mock<IDocumentUriBuilder>();
            mockUriBuilder.Setup(x => x.Build(documentId)).Returns(requestUri);

            var result = await new CompaniesHouseDocumentMetadataClient(new HttpClient(stubHttpMessageHandler), mockUriBuilder.Object)
                .GetDocumentMetadataAsync(documentId);

            result.Data.ShouldNotBeNull();
            result.Data.Filename.ShouldBe("00445790_cs01_2026-07-01");
            result.Data.Resources.ShouldNotBeNull();
            result.Data.Resources.ShouldContainKey("application/pdf");
            result.Data.Resources["application/pdf"].ContentLength.ShouldBe(82803);
        }

        private static Mock<IDocumentUriBuilder> SetupRequestUri(Uri catchUri)
        {
            var mockUriBuilder = new Mock<IDocumentUriBuilder>();
            mockUriBuilder.Setup(x => x.Build(DocumentId)).Returns(catchUri);
            return mockUriBuilder;
        }

        private static StubHttpMessageHandler SetupApiResponse(DocumentMetadataTestCase expected, Uri catchUri)
        {
            var resource = new DocumentMetadataResourceBuilder(expected).Create();
            return new StubHttpMessageHandler(catchUri, resource);
        }

        private static DocumentMetadataTestCase SetupExpectedDocumentMetadata() =>
            new DocumentMetadataTestCase
            {
                CompanyNumber = string.Empty,
                Barcode = "R4ATDSN7",
                SignificantDate = DateTime.Now,
                SignificantDateType = "makeup type",
                Category = "miscellaneous",
                Pages = 21,
                CreatedAt = DateTime.Now,
                Etag = "someEtag",
                Links = new Links
                {
                    Self = $"https://document-api.com/wibble/wobble",
                    Document = $"https://document-api.com/wibble/wobble/content",
                },
                Resources = new Dictionary<string, ResourceContentLength>
                {
                    {
                        "application/pdf", new ResourceContentLength
                        {
                            ContentLength = 442176
                        }
                    },
                    {
                        "application/xhtml+xml", new ResourceContentLength
                        {
                            ContentLength = 234122
                        }
                    }
                }
            };
    }
}

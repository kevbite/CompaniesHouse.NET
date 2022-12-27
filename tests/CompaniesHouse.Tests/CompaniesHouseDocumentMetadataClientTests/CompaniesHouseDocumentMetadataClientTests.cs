using System;
using System.Collections.Generic;
using System.Net.Http;
using CompaniesHouse.Response.Document;
using CompaniesHouse.UriBuilders;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace CompaniesHouse.Tests.CompaniesHouseDocumentMetadataClientTests
{
    [TestFixture]
    public class CompaniesHouseDocumentMetadataClientTests
    {
        private const string DocumentId = "wibble";
        private DocumentMetadataTestCase _expected;
        private CompaniesHouseClientResponse<DocumentMetadata> _result;

        [SetUp]
        public void GivenAClient_WhenGettingDocumentMetadata()
        {
            _expected = SetupExpectedDocumentMetadata();
            var requestUri = new Uri($"https://document-api.companieshouse.gov.uk/document/{DocumentId}");
            var stubHttpMessageHandler = SetupApiResponse(_expected, requestUri);
            var mockUriBuilder = SetupRequestUri(requestUri);

            _result = new CompaniesHouseDocumentMetadataClient(new HttpClient(stubHttpMessageHandler), mockUriBuilder.Object)
                .GetDocumentMetadataAsync(DocumentId).Result;
        }

        [Test]
        public void ThenDocumentMetadataIsCorrect() => _result.Data.ShouldBeEquivalentTo(_expected);

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

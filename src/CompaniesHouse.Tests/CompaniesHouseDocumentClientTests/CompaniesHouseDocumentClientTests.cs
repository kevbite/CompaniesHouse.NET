using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Response.Document;
using CompaniesHouse.UriBuilders;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace CompaniesHouse.Tests.CompaniesHouseDocumentClientTests
{
    [TestFixture]
    public class CompaniesHouseDocumentClientTests
    {
        private CompaniesHouseClientResponse<DocumentDownload> _result;
        private const string ExpectedMediaType = "application/pdf";
        private const string ExpectedContent = "test pdf";
        private const string DocumentId = "wibble";

        [SetUp]
        public async Task GivenAClient_WhenDownloadingDocument()
        {
            var requestUri = new Uri($"https://document-api.companieshouse.gov.uk/document/{DocumentId}/content");
            var stubHttpMessageHandler = new StubHttpMessageHandler(requestUri, ExpectedContent, ExpectedMediaType);
            var mockUriBuilder = new Mock<IDocumentUriBuilder>();
            mockUriBuilder.Setup(x => x.WithContent()).Returns(mockUriBuilder.Object);
            mockUriBuilder.Setup(x => x.Build(DocumentId)).Returns(requestUri.ToString());

            _result = await new CompaniesHouseDocumentClient(new HttpClient(stubHttpMessageHandler), mockUriBuilder.Object).DownloadDocumentAsync(DocumentId);
        }

        [Test]
        public void ThenDocumentContentIsCorrect()
        {
            var memoryStream = new MemoryStream();
            _result.Data.Content.CopyToAsync(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            new StreamReader(memoryStream).ReadToEnd().Should().Be(ExpectedContent);
        }
    }
}

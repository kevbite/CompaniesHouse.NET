using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Response.Document;
using CompaniesHouse.UriBuilders;
using Moq;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.CompaniesHouseDocumentClientTests
{
    public class CompaniesHouseDocumentClientTests : IAsyncLifetime
    {
        private CompaniesHouseResponse<DocumentDownload> _result;
        private const string ExpectedMediaType = "application/pdf";
        private const string ExpectedContent = "test pdf";
        private const string DocumentId = "wibble";

        public async Task InitializeAsync()
        {
            var requestUri = new Uri($"https://document-api.companieshouse.gov.uk/document/{DocumentId}/content");
            var stubHttpMessageHandler = new StubHttpMessageHandler(requestUri, ExpectedContent, ExpectedMediaType);
            var mockUriBuilder = new Mock<IDocumentUriBuilder>();
            mockUriBuilder.Setup(x => x.Build(DocumentId)).Returns(requestUri);

            _result = await new CompaniesHouseDocumentDownloadClient(new HttpClient(stubHttpMessageHandler), mockUriBuilder.Object).DownloadDocumentAsync(DocumentId);
        }

        public Task DisposeAsync() => Task.CompletedTask;

        [Fact]
        public async Task ThenDocumentContentIsCorrect()
        {
            using var memoryStream = new MemoryStream();
            await _result.Data.Content.CopyToAsync(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            new StreamReader(memoryStream).ReadToEnd().ShouldBe(ExpectedContent);
        }
    }
}

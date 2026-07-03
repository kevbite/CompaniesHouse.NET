using System.IO;
using System.Threading.Tasks;
using CompaniesHouse.Response.Document;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.DocumentTests
{
    
    public class DocumentDownloadTests : DocumentTestBase<DocumentDownload>
    {
        private const string DocumentId = "Mw2JX3NUZqy8_TwPkbHJSsZH1Xz-MygUbnurqpZZwvU";
        private CompaniesHouseResponse<DocumentDownload> _result = null!;

        
        protected override async Task When() => await DownloadingDocument();

        private async Task DownloadingDocument() => _result = await Client.DownloadDocumentAsync(DocumentId);

        [IntegrationFact]
        public async Task ThenDocumentContentIsNotEmpty()
        {
            using var memoryStream = new MemoryStream();
            await _result.Data.Content.CopyToAsync(memoryStream);

            _result.Data.ContentLength.ShouldNotBeNull();
            _result.Data.ContentLength.Value.ShouldBe(memoryStream.Length);
            _result.Data.ContentType.ShouldNotBeNullOrEmpty();
        }
    }

    
    public class DocumentDownloadTestsInvalid : DocumentTestBase<DocumentDownload>
    {
        private const string DocumentId = "000000000000000000000000000000";
        private CompaniesHouseResponse<DocumentDownload> _result = null!;

        
        protected override async Task When() => await DownloadingDocument();

        private async Task DownloadingDocument() => _result = await Client.DownloadDocumentAsync(DocumentId);

        [IntegrationFact]
        public void ThenDocumentDataIsNull() => _result.ShouldBeOfType<CompaniesHouseResponse<DocumentDownload>.NotFound>();
    }
}

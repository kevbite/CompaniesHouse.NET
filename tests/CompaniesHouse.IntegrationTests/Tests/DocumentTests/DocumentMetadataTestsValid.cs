using System.Threading.Tasks;
using CompaniesHouse.Response.Document;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.DocumentTests
{

    public class DocumentTestsValid : DocumentTestBase<DocumentMetadata>
    {
        private const string DocumentId = "IHFGB_pcm7rSIRefsfuXK1MDkLFxrSoHbKKAgY7OTxk";


        protected override async Task When() => await RetrievingDocumentMetadata();

        private async Task RetrievingDocumentMetadata() => Result = await Client.GetDocumentMetadataAsync(DocumentId);

        [Fact]
        public void ThenDocumentMetadataAreNotEmpty()
        {
            Result.Data.CompanyNumber.ShouldNotBeNullOrEmpty();
            Result.Data.Resources.ShouldNotBeNull();
            Result.Data.Resources.ShouldNotBeEmpty();
        }

        [Fact]
        public void ThenObservedFilenameAndDocumentLinkAreReturned()
        {
            Result.Data.Filename.ShouldNotBeNullOrWhiteSpace();
            Result.Data.Links?.Document.ShouldNotBeNullOrWhiteSpace();
        }
    }
}

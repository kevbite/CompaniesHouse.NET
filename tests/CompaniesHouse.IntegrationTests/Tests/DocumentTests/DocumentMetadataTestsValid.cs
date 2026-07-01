using System.Threading.Tasks;
using CompaniesHouse.Response.Document;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.DocumentTests
{
    
    public class DocumentTestsValid : DocumentTestBase<DocumentMetadata>
    {
        private const string DocumentId = "FIxRR8teCKodjkBLRDHv2Cb8y0-nQ7T5G3BEXfWtOu4";

        
        protected override async Task When() => await RetrievingDocumentMetadata();

        private async Task RetrievingDocumentMetadata() => Result = await Client.GetDocumentMetadataAsync(DocumentId);

        [Fact]
        public void ThenDocumentMetadataAreNotEmpty()
        {
            Result.Data.CompanyNumber.ShouldNotBeNullOrEmpty();
            Result.Data.Resources.ShouldNotBeNull();
            Result.Data.Resources.ShouldNotBeEmpty();
        }
    }
}

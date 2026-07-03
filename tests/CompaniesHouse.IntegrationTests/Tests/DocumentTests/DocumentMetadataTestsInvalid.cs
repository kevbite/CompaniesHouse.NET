using System.Threading.Tasks;
using CompaniesHouse.Response.Document;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.DocumentTests
{
    
    public class DocumentTestsInvalid : DocumentTestBase<DocumentMetadata>
    {
        private const string DocumentId = "0000000000000000-00000000000000";

        
        protected override async Task When() => await RetrievingDocumentMetadata();

        private async Task RetrievingDocumentMetadata()
            => Result = await Client.GetDocumentMetadataAsync(DocumentId);

        [IntegrationFact]
        public void ThenDocumentMetadataIsNull() => Result.ShouldBeOfType<CompaniesHouseResponse<DocumentMetadata>.NotFound>();
    }
}
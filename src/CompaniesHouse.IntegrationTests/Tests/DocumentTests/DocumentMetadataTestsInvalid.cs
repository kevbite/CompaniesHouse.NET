using System.Threading.Tasks;
using CompaniesHouse.Response.DocumentMetadata;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.DocumentTests
{
    [TestFixture]
    public class DocumentTestsInvalid : DocumentTestBase<DocumentMetadata>
    {
        private const string DocumentId = "0000000000000000-00000000000000";

        [SetUp]
        protected override async Task When() => await RetrievingDocumentMetadata().ConfigureAwait(false);

        private async Task RetrievingDocumentMetadata()
            => Result = await Client.GetDocumentMetadataAsync(DocumentId).ConfigureAwait(false);

        [Test]
        public void ThenDocumentMetadataIsNull() => Assert.Null(Result.Data);
    }
}
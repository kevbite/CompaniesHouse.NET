using System.Threading.Tasks;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.DocumentMetadataTests
{
    [TestFixture]
    public class DocumentMetadataTestsInvalid : DocumentMetadataTestBase
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
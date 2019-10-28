using System.Threading.Tasks;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.DocumentMetadataTests
{
    [TestFixture]
    public class DocumentMetadataTestsValid : DocumentMetadataTestBase
    {
        private const string DocumentId = "FIxRR8teCKodjkBLRDHv2Cb8y0-nQ7T5G3BEXfWtOu4";

        [SetUp]
        protected override async Task When() => await RetrievingDocumentMetadata().ConfigureAwait(false);

        private async Task RetrievingDocumentMetadata() => Result = await Client.GetDocumentMetadataAsync(DocumentId).ConfigureAwait(false);

        [Test]
        public void ThenDocumentMetadataAreNotEmpty()
        {
            Assert.That(Result.Data.CompanyNumber, Is.Not.Null.Or.Empty);
            Assert.That(Result.Data.Resources, Is.Not.Null.Or.Empty);
        }
    }
}

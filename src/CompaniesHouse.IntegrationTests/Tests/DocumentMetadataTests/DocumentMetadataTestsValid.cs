using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.DocumentMetadataTests
{
    [TestFixture]
    public class DocumentMetadataTestsValid : DocumentMetadataTestBase
    {
        private const string DocumentId = "FIxRR8teCKodjkBLRDHv2Cb8y0-nQ7T5G3BEXfWtOu4";

        [SetUp]
        protected override void When() => RetrievingDocumentMetadata();

        private void RetrievingDocumentMetadata() => Result = Client.GetDocumentMetadataAsync(DocumentId).Result;

        [Test]
        public void ThenDocumentMetadataAreNotEmpty()
        {
            Assert.That(Result.Data.CompanyNumber, Is.Not.Null.Or.Empty);
            Assert.That(Result.Data.Resources, Is.Not.Null.Or.Empty);
        }
    }
}

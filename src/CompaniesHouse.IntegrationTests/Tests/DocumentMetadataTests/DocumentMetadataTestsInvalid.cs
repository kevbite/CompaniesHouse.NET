using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.DocumentMetadataTests
{
    [TestFixture]
    public class DocumentMetadataTestsInvalid : DocumentMetadataTestBase
    {
        private const string DocumentId = "0000000000000000-00000000000000";

        [SetUp]
        protected override void When() => RetrievingDocumentMetadata();

        private void RetrievingDocumentMetadata() => Result = Client.GetDocumentMetadataAsync(DocumentId).Result;

        [Test]
        public void ThenDocumentMetadataIsNull() => Assert.Null(Result.Data);
    }
}
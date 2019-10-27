using CompaniesHouse.Response.DocumentMetadata;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.DocumentTests
{
    [TestFixture]
    public class DocumentMetadataTestsInvalid : DocumentTestBase<DocumentMetadata>
    {
        private const string DocumentId = "0000000000000000-00000000000000";

        [SetUp]
        protected override void When() => RetrievingDocumentMetadata();

        private void RetrievingDocumentMetadata() => Result = Client.GetDocumentMetadataAsync(DocumentId).Result;

        [Test]
        public void ThenDocumentMetadataIsNull() => Assert.Null(Result.Data);
    }
}
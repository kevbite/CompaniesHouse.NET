using System.IO;
using System.Threading.Tasks;
using CompaniesHouse.Response.Document;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.DocumentTests
{
    [TestFixture]
    public class DocumentDownloadTests : DocumentTestBase<DocumentDownload>
    {
        private const string DocumentId = "Mw2JX3NUZqy8_TwPkbHJSsZH1Xz-MygUbnurqpZZwvU";
        private CompaniesHouseClientResponse<DocumentDownload> _result;

        [SetUp]
        protected override async Task When() => await DownloadingDocument();

        private async Task DownloadingDocument() => _result = await Client.DownloadDocumentAsync(DocumentId);

        [Test]
        public async Task ThenDocumentContentIsNotEmpty()
        {
            using var memoryStream = new MemoryStream();
            await _result.Data.Content.CopyToAsync(memoryStream);

            Assert.AreEqual(_result.Data.ContentLength, memoryStream.Length);
            Assert.That(_result.Data.ContentType, Is.Not.Null.Or.Not.Empty);
        }
    }

    [TestFixture]
    public class DocumentDownloadTestsInvalid : DocumentTestBase<DocumentDownload>
    {
        private const string DocumentId = "000000000000000000000000000000";
        private CompaniesHouseClientResponse<DocumentDownload> _result;

        [SetUp]
        protected override async Task When() => await DownloadingDocument();

        private async Task DownloadingDocument() => _result = await Client.DownloadDocumentAsync(DocumentId);

        [Test]
        public void ThenDocumentDataIsNull() => Assert.Null(_result.Data);
    }
}

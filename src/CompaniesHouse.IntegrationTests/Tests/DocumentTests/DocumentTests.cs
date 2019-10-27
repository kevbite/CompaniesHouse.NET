using System.IO;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.DocumentTests
{
    public class DocumentTests : DocumentTestBase<Stream>
    {
        private const string TestPdf = "test.pdf";

        [SetUp]
        protected override void When() => DownloadingDocument();

        private void DownloadingDocument()
        {
            using var fileStream = File.Open(TestPdf, FileMode.OpenOrCreate);
            Client
                .DownloadDocumentAsync("Mw2JX3NUZqy8_TwPkbHJSsZH1Xz-MygUbnurqpZZwvU")
                .Result.Data.CopyToAsync(fileStream)
                .ConfigureAwait(false).GetAwaiter().GetResult();

        }

        [Test]
        public void ThenFileIsDownloaded()
        {
            Assert.True(File.Exists(TestPdf));
            Assert.Greater(File.ReadAllBytes(TestPdf).Length, 0L);
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(TestPdf)) File.Delete(TestPdf);
        }
    }
}

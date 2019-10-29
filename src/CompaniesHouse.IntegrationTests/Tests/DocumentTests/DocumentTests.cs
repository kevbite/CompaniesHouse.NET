using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.DocumentTests
{
    public class DocumentTests : DocumentTestBase<Stream>
    {
        private const string TestPdf = "test.pdf";

        [SetUp]
        protected override async Task When() => await DownloadingDocument();

        private async Task DownloadingDocument()
        {
            using var fileStream = File.Open(TestPdf, FileMode.OpenOrCreate);
            await Client.DownloadDocumentAsync("Mw2JX3NUZqy8_TwPkbHJSsZH1Xz-MygUbnurqpZZwvU").Result
                .Data.CopyToAsync(fileStream);
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

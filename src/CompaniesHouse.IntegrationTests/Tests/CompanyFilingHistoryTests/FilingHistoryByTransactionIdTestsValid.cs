using System.Threading.Tasks;
using CompaniesHouse.Response.CompanyFiling;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyFilingHistoryTests
{
    [TestFixture]
    public class FilingHistoryByTransactionIdTestsValid : CompanyFilingHistoryTestBase
    {
        private const string InvalidCompanyNumber = "00445790";
        private const string InvalidTransactionId = "QUE3UDBHVU9hZGlxemtjeA";

        private CompaniesHouseClientResponse<FilingHistoryItem> _result;

        protected override async Task When()
        {
            await WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
                .ConfigureAwait(false);
        }

        [Test]
        public void ThenTheDataItemsAreNull()
        {
            Assert.That(_result.Data, Is.Not.Null);
        }

        private async Task WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
        {
            _result = await _client.GetFilingHistoryByTransactionAsync(InvalidCompanyNumber, InvalidTransactionId)
                .ConfigureAwait(false);
        }
    }
}
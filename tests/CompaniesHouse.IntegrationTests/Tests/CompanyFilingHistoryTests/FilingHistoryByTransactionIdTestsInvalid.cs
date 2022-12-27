using System.Threading.Tasks;
using CompaniesHouse.Response.CompanyFiling;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyFilingHistoryTests
{
    [TestFixture]
    public class FilingHistoryByTransactionIdTestsInvalid : CompanyFilingHistoryTestBase
    {
        private const string InvalidCompanyNumber = "ABC00000";
        private const string InvalidTransactionId = "00000000";

        private CompaniesHouseClientResponse<FilingHistoryItem> _result;

        protected override async Task When()
        {
            await WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
                .ConfigureAwait(false);
        }

        [Test]
        public void ThenTheDataItemsAreNull()
        {
            Assert.That(_result.Data, Is.Null);
        }

        private async Task WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
        {
            _result = await _client.GetFilingHistoryByTransactionAsync(InvalidCompanyNumber, InvalidTransactionId)
                .ConfigureAwait(false);
        }
    }
}
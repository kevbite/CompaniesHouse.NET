using System.Threading.Tasks;
using CompaniesHouse.Response.CompanyFiling;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyFilingHistoryTests
{
    [TestFixture]
    public class CompanyFilingHistoryTestsInvalid : CompanyFilingHistoryTestBase
    {
        private const string InvalidCompanyNumber = "ABC00000";

        private CompaniesHouseClientResponse<CompanyFilingHistory> _result;

        protected override async Task When()
        {
            await WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany().ConfigureAwait(false);
        }

        [Test]
        public void ThenTheDataItemsAreNull()
        {
            Assert.That(_result.Data.Items, Is.Null);
        }

        private async Task WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
        {
            _result = await _client.GetCompanyFilingHistoryAsync(InvalidCompanyNumber);
        }
    }
}

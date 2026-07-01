using System.Threading.Tasks;
using CompaniesHouse.Response.CompanyFiling;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyFilingHistoryTests
{

    public class CompanyFilingHistoryTestsInvalid : CompanyFilingHistoryTestBase
    {
        private const string InvalidCompanyNumber = "ABC00000";

        private CompaniesHouseClientResponse<CompanyFilingHistory> _result = null!;

        protected override async Task When()
        {
            await WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
                ;
        }

        [Fact]
        public void ThenTheDataItemsAreNull()
        {
            _result.Data.ShouldNotBeNull();
            _result.Data.Items.ShouldBeEmpty();
        }

        private async Task WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
        {
            _result = await _client.GetCompanyFilingHistoryAsync(InvalidCompanyNumber)
                ;
        }
    }
}

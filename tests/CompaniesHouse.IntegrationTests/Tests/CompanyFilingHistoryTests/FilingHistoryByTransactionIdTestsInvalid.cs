using System.Threading.Tasks;
using CompaniesHouse.Response.CompanyFiling;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyFilingHistoryTests
{
    
    public class FilingHistoryByTransactionIdTestsInvalid : CompanyFilingHistoryTestBase
    {
        private const string InvalidCompanyNumber = "ABC00000";
        private const string InvalidTransactionId = "00000000";

        private CompaniesHouseClientResponse<FilingHistoryItem> _result = null!;

        protected override async Task When()
        {
            await WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
                ;
        }

        [Fact]
        public void ThenTheDataItemsAreNull()
        {
            _result.Data.ShouldBeNull();
        }

        private async Task WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
        {
            _result = await _client.GetFilingHistoryByTransactionAsync(InvalidCompanyNumber, InvalidTransactionId)
                ;
        }
    }
}
using System.Threading.Tasks;
using CompaniesHouse.Response.CompanyFiling;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyFilingHistoryTests
{
    
    public class FilingHistoryByTransactionIdTestsValid : CompanyFilingHistoryTestBase
    {
        private const string InvalidCompanyNumber = "00445790";
        private const string InvalidTransactionId = "QUE3UDBHVU9hZGlxemtjeA";

        private CompaniesHouseClientResponse<FilingHistoryItem> _result = null!;

        protected override async Task When()
        {
            await WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
                ;
        }

        [Fact]
        public void ThenTheDataItemsAreNull()
        {
            _result.Data.ShouldNotBeNull();
        }

        private async Task WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
        {
            _result = await _client.GetFilingHistoryByTransactionAsync(InvalidCompanyNumber, InvalidTransactionId)
                ;
        }
    }
}
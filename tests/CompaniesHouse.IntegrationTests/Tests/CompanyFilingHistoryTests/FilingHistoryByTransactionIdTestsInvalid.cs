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

        private CompaniesHouseResponse<FilingHistoryItem> _result = null!;

        protected override async Task When()
        {
            await WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
                ;
        }

        [IntegrationFact]
        public void ThenTheDataItemsAreNull()
        {
            _result.ShouldBeOfType<CompaniesHouseResponse<FilingHistoryItem>.NotFound>();
        }

        private async Task WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
        {
            _result = await _client.GetFilingHistoryByTransactionAsync(InvalidCompanyNumber, InvalidTransactionId)
                ;
        }
    }
}
using System.Threading.Tasks;
using CompaniesHouse.Response.CompanyFiling;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyFilingHistoryTests
{

    public class FilingHistoryByTransactionIdTestsValid : CompanyFilingHistoryTestBase
    {
        private const string ValidCompanyNumber = "00445790";
        private const string ValidTransactionId = "MzUyNDY1MTExNmFkaXF6a2N4";

        private CompaniesHouseResponse<FilingHistoryItem> _result = null!;

        protected override async Task When()
        {
            await WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
                ;
        }

        [IntegrationFact]
        public void ThenTheDataItemsAreNull()
        {
            _result.Data.ShouldNotBeNull();
        }

        [IntegrationFact]
        public void ThenObservedFieldsAreReturned()
        {
            _result.Data.Links?.DocumentMetaData.ShouldNotBeNullOrWhiteSpace();
            _result.Data.Category.Value.ShouldNotBeNullOrWhiteSpace();
        }

        private async Task WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
        {
            _result = await _client.GetFilingHistoryByTransactionAsync(ValidCompanyNumber, ValidTransactionId)
                ;
        }
    }
}
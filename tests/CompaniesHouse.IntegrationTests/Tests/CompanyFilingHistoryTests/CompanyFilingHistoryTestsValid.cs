using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompaniesHouse.Response.CompanyFiling;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyFilingHistoryTests
{
    public class CompanyFilingHistoryTestsValid
    {
        private readonly CompaniesHouseClient _client;

        public CompanyFilingHistoryTestsValid()
        {
            _client = new CompaniesHouseClient(new CompaniesHouseSettings(Keys.ApiKey));
        }

        [IntegrationTheory]
        [InlineData("03977902")]
        [InlineData("00445790")]
        [InlineData("00002065")]
        [InlineData("09965459")]
        [InlineData("06768813")]
        [InlineData("00059337")]
        [InlineData("SC171417")]
        [InlineData("09018331")]
        public async Task ThenTheDataItemsAreNotEmpty(string companyNumber)
        {
            var page = 0;
            var size = 100;
            var results = new List<FilingHistoryItem>();

            CompaniesHouseResponse<CompanyFilingHistory> result;
            do
            {
                result = await _client.GetCompanyFilingHistoryAsync(companyNumber, page++ * size, size);
                results.AddRange(result.Data.Items);
            } while (result.Data.Items.Any());

            results.ShouldNotBeEmpty();
        }

        [IntegrationFact]
        public async Task ThenKnownFilingHistoryIncludesObservedPaginationFields()
        {
            var result = await _client.GetCompanyFilingHistoryAsync("00445790");

            result.Data.TotalCount.ShouldBeGreaterThan(0);
            result.Data.ItemsPerPage.ShouldBeGreaterThan(0);
            result.Data.Items.ShouldNotBeEmpty();
            result.Data.Items[0].Category.Value.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
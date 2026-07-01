using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.CompanySearch;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.SearchingTests
{
    public class CompanySearchTests
    {
        private readonly CompaniesHouseClient _client;

        public CompanySearchTests()
        {
            _client = new CompaniesHouseClient(new CompaniesHouseSettings(Keys.ApiKey));
        }

        [Theory]
        [InlineData("brighouse computers")]
        [InlineData("British Gas")]
        [InlineData("Bay Horse")]
        public async Task ThenCompaniesAreReturned(string query)
        {
            var result = await _client.SearchCompanyAsync(new SearchCompanyRequest { Query = query, StartIndex = 0, ItemsPerPage = 100 });

            result.Data.Companies.ShouldNotBeEmpty();
        }
    }
}
using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.AllSearch;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.SearchingTests
{
    public class AllSearchTests
    {
        private readonly CompaniesHouseClient _client;

        public AllSearchTests()
        {
            _client = new CompaniesHouseClient(new CompaniesHouseSettings(Keys.ApiKey));
        }

        [Theory]
        [InlineData("British Gas")]
        [InlineData("Kevin")]
        public async Task ThenItemsAreReturned(string query)
        {
            var result = await _client.SearchAllAsync(new SearchAllRequest { Query = query });

            result.Data.Items.ShouldNotBeEmpty();
        }
    }
}
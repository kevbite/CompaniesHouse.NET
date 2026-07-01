using System.Threading.Tasks;
using CompaniesHouse.Request;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.SearchingTests
{
    public class DissolvedCompaniesSearchTests
    {
        private readonly CompaniesHouseClient _client;

        public DissolvedCompaniesSearchTests()
        {
            _client = new CompaniesHouseClient(new CompaniesHouseSettings(Keys.ApiKey));
        }

        [Theory]
        [InlineData("CARILLION")]
        [InlineData("BLOCKBUSTER")]
        public async Task ThenCompaniesAreReturned(string query)
        {
            var result = await _client.SearchDissolvedCompaniesAsync(new SearchDissolvedCompaniesRequest
            {
                Query = query,
                SearchType = "best-match",
                Size = 25,
            });

            result.Data.ShouldNotBeNull();
            result.Data.Items.ShouldNotBeEmpty();
        }
    }
}

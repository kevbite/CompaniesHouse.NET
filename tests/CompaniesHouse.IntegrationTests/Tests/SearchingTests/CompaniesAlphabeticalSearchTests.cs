using System.Threading.Tasks;
using CompaniesHouse.Request;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.SearchingTests
{
    public class CompaniesAlphabeticalSearchTests
    {
        private readonly CompaniesHouseClient _client;

        public CompaniesAlphabeticalSearchTests()
        {
            _client = new CompaniesHouseClient(new CompaniesHouseSettings(Keys.ApiKey));
        }

        [Theory]
        [InlineData("TESCO")]
        [InlineData("TESCO PERSONAL FINANCE")]
        public async Task ThenCompaniesAreReturned(string query)
        {
            var result = await _client.SearchCompaniesAlphabeticallyAsync(new SearchCompaniesAlphabeticallyRequest
            {
                Query = query,
                Size = 25,
            });

            result.Data.ShouldNotBeNull();
            result.Data.Items.ShouldNotBeEmpty();
        }
    }
}

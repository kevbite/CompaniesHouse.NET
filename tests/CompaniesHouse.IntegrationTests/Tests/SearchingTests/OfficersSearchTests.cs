using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.OfficerSearch;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.SearchingTests
{
    public class OfficersSearchTests
    {
        private readonly CompaniesHouseClient _client;

        public OfficersSearchTests()
        {
            _client = new CompaniesHouseClient(new CompaniesHouseSettings(Keys.ApiKey));
        }

        [Fact]
        public async Task ThenOfficersAreReturned()
        {
            var result = await _client.SearchOfficerAsync(new SearchOfficerRequest { Query = "Kevin" });

            result.Data.Officers.ShouldNotBeEmpty();
        }
    }
}
using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.DisqualifiedOfficersSearch;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.SearchingTests
{
    public class DisqualifiedOfficersSearchTests
    {
        private readonly CompaniesHouseClient _client;

        public DisqualifiedOfficersSearchTests()
        {
            _client = new CompaniesHouseClient(new CompaniesHouseSettings(Keys.ApiKey));
        }

        [Fact]
        public async Task ThenDisqualifiedOfficersAreReturned()
        {
            var result = await _client.SearchDisqualifiedOfficerAsync(new SearchDisqualifiedOfficerRequest { Query = "Kevin" });

            result.Data.DisqualifiedOfficers.ShouldNotBeEmpty();
        }
    }
}
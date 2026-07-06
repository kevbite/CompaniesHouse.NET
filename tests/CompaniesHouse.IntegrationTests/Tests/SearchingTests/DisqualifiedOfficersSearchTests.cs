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

        [IntegrationFact]
        public async Task ThenDisqualifiedOfficersAreReturned()
        {
            var result = await _client.SearchDisqualifiedOfficerAsync(new SearchDisqualifiedOfficerRequest { Query = "Kevin" });

            (result.Data.DisqualifiedOfficers ?? []).ShouldNotBeEmpty();
        }

        [IntegrationFact]
        public async Task ThenPagingMetadataAndDateOfBirthAreReturned()
        {
            var result = await _client.SearchDisqualifiedOfficerAsync(new SearchDisqualifiedOfficerRequest { Query = "john", ItemsPerPage = 20 });

            result.Data.PageNumber.ShouldBe(1);
            var officers = result.Data.DisqualifiedOfficers ?? [];
            officers.ShouldNotBeEmpty();
            officers[0].DateOfBirth.Year.ShouldBeGreaterThan(1900);
        }
    }
}
using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.OfficerSearch;
using System.Linq;
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

        [IntegrationFact]
        public async Task ThenOfficersAreReturned()
        {
            var result = await _client.SearchOfficerAsync(new SearchOfficerRequest { Query = "Kevin" });

            (result.Data.Officers ?? []).ShouldNotBeEmpty();
        }

        [IntegrationFact]
        public async Task ThenLiveOfficerBirthMonthAndPagingMetadataAreReturned()
        {
            var result = await _client.SearchOfficerAsync(new SearchOfficerRequest { Query = "Alan Sugar", ItemsPerPage = 20 });

            var officer = (result.Data.Officers ?? []).First(x => x.Title == "Lord Alan Michael SUGAR" && x.DateOfBirth?.Year == 1947);
            result.Data.PageNumber.ShouldBe(1);
            officer.DateOfBirth.ShouldNotBeNull();
            officer.DateOfBirth.Month.ShouldBe(3);
        }
    }
}
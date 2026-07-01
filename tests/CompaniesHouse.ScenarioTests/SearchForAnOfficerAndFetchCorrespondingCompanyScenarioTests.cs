using System.Linq;
using System.Threading.Tasks;
using CompaniesHouse.Request;
using Shouldly;
using Xunit;

namespace CompaniesHouse.ScenarioTests
{
    public class SearchForAnOfficerAndFetchCorrespondingCompanyScenarioTests
    {
        private ICompaniesHouseClient _client;

        public SearchForAnOfficerAndFetchCorrespondingCompanyScenarioTests()
        {
            var settings = new CompaniesHouseSettings(Keys.ApiKey);
            _client = new CompaniesHouseClient(settings);
        }

        [Fact]
        public async Task RunScenario()
        {
            var officersSearch = await _client.SearchOfficerAsync(new SearchOfficerRequest() { Query = "Richard Branson" });

            var foundOfficer = officersSearch.Data.Officers.Single(x => x.DateOfBirth?.Year == 1950 && x.DateOfBirth?.Month == 7);

            var officerAppointments = await _client.GetAppointmentsAsync(foundOfficer.OfficerId);

            var companyNumber = officerAppointments.Data.Items
                .Single(x => x.Appointed.CompanyName == "VIRGIN LIMITED")
                .Appointed.CompanyNumber;

            var companyProfile = await _client.GetCompanyProfileAsync(companyNumber);

            companyProfile.Data.ShouldNotBeNull();
            companyProfile.Data.CompanyNumber.ShouldBe("01946167");
        }
    }
}
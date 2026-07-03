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
            var officers = officersSearch.Data.Officers ?? [];

            var foundOfficer = officers.Single(x => x.DateOfBirth?.Year == 1950 && x.DateOfBirth?.Month == 7);
            foundOfficer.OfficerId.ShouldNotBeNullOrWhiteSpace();

            var officerAppointments = await _client.GetAppointmentsAsync(foundOfficer.OfficerId!);
            var appointments = officerAppointments.Data.Items ?? [];

            var companyNumber = appointments
                .Single(x => x.Appointed?.CompanyName == "VIRGIN LIMITED")
                .Appointed?.CompanyNumber;
            companyNumber.ShouldNotBeNullOrWhiteSpace();

            var companyProfile = await _client.GetCompanyProfileAsync(companyNumber!);

            companyProfile.Data.ShouldNotBeNull();
            companyProfile.Data.CompanyNumber.ShouldBe("01946167");
        }
    }
}
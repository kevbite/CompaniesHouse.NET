using System.Linq;
using System.Threading.Tasks;
using CompaniesHouse.Request;
using NUnit.Framework;

namespace CompaniesHouse.ScenarioTests
{
    public class SearchForAnOfficerAndFetchCorrespondingCompanyScenarioTests
    {
        private ICompaniesHouseClient _client;

        [SetUp]
        public void Setup()
        {
            var settings = new CompaniesHouseSettings(Keys.ApiKey);
            _client = new CompaniesHouseClient(settings);
        }

        [Test]
        public async Task RunScenario()
        {
            var officersSearch = await _client.SearchOfficerAsync(new SearchOfficerRequest() {Query = "Richard Branson" })
                .ConfigureAwait(false);

            var foundOfficer = officersSearch.Data.Officers.Single(x => x.DateOfBirth?.Year == 1950 && x.DateOfBirth?.Month == 7);

            var officerAppointments = await _client.GetAppointmentsAsync(foundOfficer.OfficerId)
                .ConfigureAwait(false);

            var companyNumber = officerAppointments.Data.Items
                .Single(x => x.Appointed.CompanyName == "VIRGIN LIMITED")
                .Appointed.CompanyNumber;

            var companyProfile = await _client.GetCompanyProfileAsync(companyNumber)
                .ConfigureAwait(false);

            Assert.NotNull(companyProfile.Data);
            Assert.AreEqual("01946167", companyProfile.Data.CompanyNumber);
        }
    }
}
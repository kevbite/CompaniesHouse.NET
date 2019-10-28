using System;
using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.OfficerSearch;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.SearchingTests
{
    [TestFixture]
    public class OfficersSearchTests
    {
        private CompaniesHouseClient _client;
        private CompaniesHouseClientResponse<OfficerSearch> _result;
        
        [OneTimeSetUp]
        public void GivenACompaniesHouseClient()
        {
            var settings = new CompaniesHouseSettings(Keys.ApiKey);

            _client = new CompaniesHouseClient(settings);
        }

        [SetUp]
        public async Task WhenSearchingForAOfficer()
        {
            _result = await _client.SearchOfficerAsync(new SearchRequest() { Query = "Kevin" })
                .ConfigureAwait(false);
        }

        [Test]
        public void ThenOfficersAreReturned()
        {
            Assert.That(_result.Data.Officers, Is.Not.Empty);
        }
    }
}
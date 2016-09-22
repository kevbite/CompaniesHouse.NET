using System;
using LiberisLabs.CompaniesHouse.Request;
using LiberisLabs.CompaniesHouse.Response.OfficerSearch;
using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.IntegrationTests.Tests.SearchingTests
{
    [TestFixture]
    public class OfficersSearchTests
    {
        private CompaniesHouseClient _client;
        private CompaniesHouseClientResponse<OfficerSearch> _result;
        
        [OneTimeSetUp]
        public void GivenACompaniesHouseClient()
        {
            var apiKey = Environment.GetEnvironmentVariable("CompaniesHouseApiKey");

            var settings = new CompaniesHouseSettings(apiKey);

            _client = new CompaniesHouseClient(settings);
        }

        [SetUp]
        public void WhenSearchingForAOfficer()
        {
            _result = _client.SearchOfficerAsync(new SearchRequest() { Query = "Kevin" }).Result;
        }

        [Test]
        public void ThenOfficersAreReturned()
        {
            Assert.That(_result.Data.Officers, Is.Not.Empty);
        }
    }
}
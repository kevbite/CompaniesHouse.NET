using System;
using LiberisLabs.CompaniesHouse.Request;
using LiberisLabs.CompaniesHouse.Response.CompanySearch;
using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.IntegrationTests.Tests
{
    [TestFixture]
    public class CompanySearchTests
    {
        private CompaniesHouseClient _client;
        private CompaniesHouseClientResponse<CompanySearch> _result;

        [TestFixtureSetUp]
        public void GivenACompaniesHouseClient()
        {
            var apiKey = Environment.GetEnvironmentVariable("CompaniesHouseApiKey");

            var settings = new CompaniesHouseSettings(apiKey);

            _client = new CompaniesHouseClient(settings);
        }

        [SetUp]
        public void WhenSearchingForACompany()
        {
            _result = _client.SearchCompanyAsync(new CompanySearchRequest() {Query = "Liberis"}).Result;
        }

        [Test]
        public void ThenComapniesAreReturned()
        {
            Assert.That(_result.Data.Companies, Is.Not.Empty);
        }
    }
}

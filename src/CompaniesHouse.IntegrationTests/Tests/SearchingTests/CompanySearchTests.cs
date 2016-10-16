using System;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.CompanySearch;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.SearchingTests
{
    [TestFixture("Liberis")]
    [TestFixture("British Gas")]
    public class CompanySearchTests
    {
        private readonly string _query;
        private CompaniesHouseClient _client;
        private CompaniesHouseClientResponse<CompanySearch> _result;

        public CompanySearchTests(string query)
        {
            _query = query;
        }

        [OneTimeSetUp]
        public void GivenACompaniesHouseClient()
        {
            var settings = new CompaniesHouseSettings(Keys.ApiKey);

            _client = new CompaniesHouseClient(settings);
        }

        [SetUp]
        public void WhenSearchingForACompany()
        {
            _result = _client.SearchCompanyAsync(new SearchRequest() { Query = _query }).Result;
        }

        [Test]
        public void ThenCompaniesAreReturned()
        {
            Assert.That(_result.Data.Companies, Is.Not.Empty);
        }
    }
}

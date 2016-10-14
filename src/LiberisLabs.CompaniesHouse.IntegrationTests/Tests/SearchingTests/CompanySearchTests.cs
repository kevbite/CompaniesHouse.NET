using System;
using LiberisLabs.CompaniesHouse.Request;
using LiberisLabs.CompaniesHouse.Response.CompanySearch;
using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.IntegrationTests.Tests.SearchingTests
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
            var apiKey = "vYiy5KBmCX0el1lmz4e-l4sDVr0-4-xAwlMw9lvs";

            var settings = new CompaniesHouseSettings(apiKey);

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

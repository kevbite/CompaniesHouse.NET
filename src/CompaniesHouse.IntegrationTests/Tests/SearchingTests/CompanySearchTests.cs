using System;
using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.CompanySearch;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.SearchingTests
{
    [TestFixture("brighouse computers")]
    [TestFixture("British Gas")]
    [TestFixture("Bay Horse")]

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
        public async Task WhenSearchingForACompany()
        {
            _result = await _client.SearchCompanyAsync(new SearchRequest() { Query = _query, StartIndex = 0, ItemsPerPage = 100 })
                .ConfigureAwait(false);
        }

        [Test]
        public void ThenCompaniesAreReturned()
        {
            Assert.That(_result.Data.Companies, Is.Not.Empty);
        }
    }
}

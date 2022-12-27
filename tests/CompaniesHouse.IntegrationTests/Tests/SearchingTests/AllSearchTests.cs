using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.AllSearch;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.SearchingTests
{
    [TestFixture("British Gas")]
    [TestFixture("Kevin")]
    public class AllSearchTests
    {
        private readonly string _query;
        private CompaniesHouseClient _client;
        private CompaniesHouseClientResponse<AllSearch> _result;

        public AllSearchTests(string query)
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
        public async Task WhenSearching()
        {
            _result = await _client.SearchAllAsync(new SearchRequest() { Query = _query })
                .ConfigureAwait(false);
        }

        [Test]
        public void ThenItemsAreReturned()
        {
            Assert.That(_result.Data.Items, Is.Not.Empty);
        }
    }
}

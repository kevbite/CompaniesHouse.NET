using System.Threading.Tasks;
using CompaniesHouse.Response.Insolvency;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyInsolvencyInformationTests
{
    [TestFixture]
    public class CompanyInsolvencyInformationTests
    {
        private CompaniesHouseClient _client;
        private CompaniesHouseClientResponse<CompanyInsolvencyInformation> _result;
        
        [OneTimeSetUp]
        public void GivenACompaniesHouseClient()
        {
            var settings = new CompaniesHouseSettings(Keys.ApiKey);

            _client = new CompaniesHouseClient(settings);
        }

        [SetUp]
        public async Task WhenSearching()
        {
            _result = await _client.GetCompanyInsolvencyInformationAsync("08749409")
                .ConfigureAwait(false);
        }

        [Test]
        public void TheItemsAreReturned()
        {
            Assert.That(_result.Data, Is.Not.Null);
        }
    }
}

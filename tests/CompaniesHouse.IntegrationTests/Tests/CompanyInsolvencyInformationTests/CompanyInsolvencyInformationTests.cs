using System.Threading.Tasks;
using CompaniesHouse.Response.Insolvency;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyInsolvencyInformationTests
{
    public class CompanyInsolvencyInformationTests
    {
        private readonly CompaniesHouseClient _client;

        public CompanyInsolvencyInformationTests()
        {
            _client = new CompaniesHouseClient(new CompaniesHouseSettings(Keys.ApiKey));
        }

        [Fact]
        public async Task TheItemsAreReturned()
        {
            var result = await _client.GetCompanyInsolvencyInformationAsync("08749409");

            result.Data.ShouldNotBeNull();
        }
    }
}
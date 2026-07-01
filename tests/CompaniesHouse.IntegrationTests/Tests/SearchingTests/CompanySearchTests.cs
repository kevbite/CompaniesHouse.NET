using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.CompanySearch;
using System.Linq;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.SearchingTests
{
    public class CompanySearchTests
    {
        private readonly CompaniesHouseClient _client;

        public CompanySearchTests()
        {
            _client = new CompaniesHouseClient(new CompaniesHouseSettings(Keys.ApiKey));
        }

        [Theory]
        [InlineData("brighouse computers")]
        [InlineData("British Gas")]
        [InlineData("Bay Horse")]
        public async Task ThenCompaniesAreReturned(string query)
        {
            var result = await _client.SearchCompanyAsync(new SearchCompanyRequest { Query = query, StartIndex = 0, ItemsPerPage = 100 });

            result.Data.Companies.ShouldNotBeEmpty();
        }

        [Fact]
        public async Task ThenForeignCompanyFieldsAreReturned()
        {
            var result = await _client.SearchCompanyAsync(new SearchCompanyRequest
            {
                Query = "absa uk permanent establishment",
                StartIndex = 0,
                ItemsPerPage = 20,
            });

            var company = result.Data.Companies.Single(x => x.CompanyNumber == "FC040879");
            result.Data.PageNumber.ShouldBe(1);
            company.AddressSnippet.ShouldBe("Absa Towers West, 15 Troye Street, Johannesburg, Gauteng 2000, South Africa");
            company.ExternalRegistrationNumber.ShouldBe("198600479406");
            company.DescriptionIdentifier.ShouldBe(["first-uk-establishment-opened-on"]);
        }

        [Fact]
        public async Task ThenRestrictionsCanBeSentToTheLiveApi()
        {
            var result = await _client.SearchCompanyAsync(new SearchCompanyRequest
            {
                Query = "tesco",
                Restrictions = "active-companies-only",
                ItemsPerPage = 10,
            });

            result.Data.ShouldNotBeNull();
            result.Data.Companies.ShouldNotBeEmpty();
        }
    }
}
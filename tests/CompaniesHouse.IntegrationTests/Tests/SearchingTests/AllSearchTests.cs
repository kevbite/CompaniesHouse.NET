using System.Linq;
using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.CompanySearch;
using CompaniesHouse.Response.Search.OfficerSearch;
using CompaniesHouse.Response.Search.AllSearch;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.SearchingTests
{
    public class AllSearchTests
    {
        private readonly CompaniesHouseClient _client;

        public AllSearchTests()
        {
            _client = new CompaniesHouseClient(new CompaniesHouseSettings(Keys.ApiKey));
        }

        [Theory]
        [InlineData("British Gas")]
        [InlineData("Kevin")]
        public async Task ThenItemsAreReturned(string query)
        {
            var result = await _client.SearchAllAsync(new SearchAllRequest { Query = query });

            result.Data.Items.ShouldNotBeEmpty();
        }

        [Fact]
        public async Task ThenPagingAndMixedItemTypesAreReturned()
        {
            var result = await _client.SearchAllAsync(new SearchAllRequest { Query = "john", ItemsPerPage = 20 });

            result.Data.PageNumber.ShouldBe(1);
            result.Data.Items.ShouldContain(x => x is Company);
            result.Data.Items.ShouldContain(x => x is Officer);
        }

        [Fact]
        public async Task ThenCompanySpecificFieldsRoundTripFromSearchAll()
        {
            var result = await _client.SearchAllAsync(new SearchAllRequest { Query = "absa uk permanent establishment", ItemsPerPage = 20 });

            var company = result.Data.Items.OfType<Company>().Single(x => x.CompanyNumber == "FC040879");
            company.CompanyNumber.ShouldBe("FC040879");
            company.AddressSnippet.ShouldBe("Absa Towers West, 15 Troye Street, Johannesburg, Gauteng 2000, South Africa");
            company.ExternalRegistrationNumber.ShouldBe("198600479406");
        }
    }
}
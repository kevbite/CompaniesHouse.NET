using System;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response;
using CompaniesHouse.Response.Search.CompaniesAlphabeticallySearch;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.CompaniesHouseSearchClientTests
{
    public class CompaniesHouseSearchClientTestsForCompaniesAlphabeticallySearch
    {
        [Fact]
        public async Task GivenAResponse_WhenSearchingCompaniesAlphabetically_ThenTheTypedPayloadIsReturned()
        {
            const string resource = """
                {
                  "items": [
                    {
                      "company_name": "ABC LIMITED",
                      "company_number": "01234567",
                      "company_status": "active",
                      "company_type": "ltd",
                      "kind": "search-results#alphabetical-search",
                      "links": { "company_profile": "/company/01234567" },
                      "ordered_alpha_key_with_id": "ABC LIMITED:01234567"
                    }
                  ],
                  "kind": "search#alphabetical-search",
                  "top_hit": {
                    "company_name": "ABC LIMITED",
                    "company_number": "01234567",
                    "company_status": "active",
                    "company_type": "ltd",
                    "kind": "search-results#alphabetical-search",
                    "links": { "company_profile": "/company/01234567" },
                    "ordered_alpha_key_with_id": "ABC LIMITED:01234567"
                  }
                }
                """;

            var uri = new Uri("https://wibble.com/alphabetical-search/companies");
            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);
            var client = new CompaniesHouseSearchClient(
                new HttpClient(handler) { BaseAddress = new Uri("https://wibble.com/") },
                new SearchUriBuilderFactory());

            var result = await client.SearchAsync<SearchCompaniesAlphabeticallyRequest, CompaniesAlphabeticallySearch>(
                new SearchCompaniesAlphabeticallyRequest { Query = "abc" });

            result.Data.Kind.ShouldBe("search#alphabetical-search");
            var items = result.Data.Items ?? [];
            items.Length.ShouldBe(1);
            result.Data.TopHit?.CompanyNumber.ShouldBe("01234567");
            var company = items[0];
            company.CompanyName.ShouldBe("ABC LIMITED");
            company.CompanyStatus.ShouldBe(CompanyStatus.Active);
            company.CompanyType.ShouldBe(CompanyType.Ltd);
            company.Links?.CompanyProfile.ShouldBe("/company/01234567");
            company.OrderedAlphaKeyWithId.ShouldBe("ABC LIMITED:01234567");
        }
    }
}

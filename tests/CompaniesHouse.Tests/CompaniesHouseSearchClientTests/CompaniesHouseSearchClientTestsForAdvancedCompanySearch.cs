using System;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response;
using CompaniesHouse.Response.Search.AdvancedCompanySearch;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.CompaniesHouseSearchClientTests
{
    public class CompaniesHouseSearchClientTestsForAdvancedCompanySearch
    {
        [Fact]
        public async Task GivenAResponse_WhenPerformingAnAdvancedCompanySearch_ThenTheTypedPayloadIsReturned()
        {
            const string resource = """
                {
                  "etag": "etag-advanced",
                  "hits": "1",
                  "items": [
                    {
                      "company_name": "ABC CIC LIMITED",
                      "company_number": "01234567",
                      "company_status": "active",
                      "company_subtype": "community-interest-company",
                      "company_type": "ltd",
                      "date_of_creation": "2010-02-03",
                      "kind": "search-results#company",
                      "links": { "company_profile": "/company/01234567" },
                      "registered_office_address": {
                        "address_line_1": "1 Example Street",
                        "address_line_2": "Suite 2",
                        "country": "England",
                        "locality": "London",
                        "postal_code": "SW1A 1AA",
                        "region": "Greater London"
                      },
                      "sic_codes": [ "62012", "62020" ]
                    }
                  ],
                  "kind": "search#advanced-search",
                  "top_hit": {
                    "company_name": "ABC CIC LIMITED",
                    "company_number": "01234567",
                    "company_status": "active",
                    "company_subtype": "community-interest-company",
                    "company_type": "ltd",
                    "date_of_creation": "2010-02-03",
                    "kind": "search-results#company",
                    "links": { "company_profile": "/company/01234567" },
                    "registered_office_address": {
                      "address_line_1": "1 Example Street",
                      "address_line_2": "Suite 2",
                      "country": "England",
                      "locality": "London",
                      "postal_code": "SW1A 1AA",
                      "region": "Greater London"
                    },
                    "sic_codes": [ "62012", "62020" ]
                  }
                }
                """;

            var uri = new Uri("https://wibble.com/advanced-search/companies");
            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);
            var client = new CompaniesHouseSearchClient(
                new HttpClient(handler) { BaseAddress = new Uri("https://wibble.com/") },
                new SearchUriBuilderFactory());

            var result = await client.SearchAsync<AdvancedCompanySearchRequest, AdvancedCompanySearch>(
                new AdvancedCompanySearchRequest { CompanyNameIncludes = "abc" });

            result.Data.ETag.ShouldBe("etag-advanced");
            result.Data.Hits.ShouldBe(1);
            result.Data.Kind.ShouldBe("search#advanced-search");
            var company = result.Data.Items[0];
            company.CompanyStatus.ShouldBe(CompanyStatus.Active);
            company.CompanySubtype.ShouldBe(CompanySubtype.CommunityInterestCompany);
            company.CompanyType.ShouldBe(CompanyType.Ltd);
            company.Links.CompanyProfile.ShouldBe("/company/01234567");
            company.RegisteredOfficeAddress.Country.ShouldBe("England");
            company.SicCodes.ShouldBe(new[] { "62012", "62020" });
            result.Data.TopHit.CompanyNumber.ShouldBe("01234567");
        }
    }
}

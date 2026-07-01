using System;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response;
using CompaniesHouse.Response.Search.DissolvedCompaniesSearch;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.CompaniesHouseSearchClientTests
{
    public class CompaniesHouseSearchClientTestsForDissolvedCompaniesSearch
    {
        [Fact]
        public async Task GivenAResponse_WhenSearchingDissolvedCompanies_ThenTheTypedPayloadIsReturned()
        {
            const string resource = """
                {
                  "etag": "etag-1",
                  "hits": "2",
                  "items": [
                    {
                      "company_name": "ABC DISSOLVED LIMITED",
                      "company_number": "01234567",
                      "company_status": "dissolved",
                      "date_of_cessation": "2023-01-20",
                      "date_of_creation": "2001-02-03",
                      "kind": "search-results#dissolved-company",
                      "matched_previous_company_name": {
                        "ceased_on": "2010-01-01",
                        "company_number": "01234567",
                        "effective_from": "2009-01-01",
                        "name": "OLD ABC LIMITED"
                      },
                      "ordered_alpha_key_with_id": "ABC DISSOLVED LIMITED:01234567",
                      "previous_company_names": [
                        {
                          "ceased_on": "2010-01-01",
                          "company_number": "01234567",
                          "effective_from": "2009-01-01",
                          "name": "OLD ABC LIMITED"
                        }
                      ],
                      "registered_office_address": {
                        "address_line_1": "1 Example Street",
                        "address_line_2": "Example House",
                        "locality": "Cardiff",
                        "postal_code": "CF14 3UZ"
                      }
                    }
                  ],
                  "kind": "search#dissolved",
                  "top_hit": {
                    "company_name": "ABC DISSOLVED LIMITED",
                    "company_number": "01234567",
                    "company_status": "dissolved",
                    "date_of_cessation": "2023-01-20",
                    "date_of_creation": "2001-02-03",
                    "kind": "search-results#dissolved-company",
                    "matched_previous_company_name": {
                      "ceased_on": "2010-01-01",
                      "company_number": "01234567",
                      "effective_from": "2009-01-01",
                      "name": "OLD ABC LIMITED"
                    },
                    "ordered_alpha_key_with_id": "ABC DISSOLVED LIMITED:01234567",
                    "previous_company_names": [
                      {
                        "ceased_on": "2010-01-01",
                        "company_number": "01234567",
                        "effective_from": "2009-01-01",
                        "name": "OLD ABC LIMITED"
                      }
                    ],
                    "registered_office_address": {
                      "address_line_1": "1 Example Street",
                      "address_line_2": "Example House",
                      "locality": "Cardiff",
                      "postal_code": "CF14 3UZ"
                    }
                  }
                }
                """;

            var uri = new Uri("https://wibble.com/dissolved-search/companies");
            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);
            var client = new CompaniesHouseSearchClient(
                new HttpClient(handler) { BaseAddress = new Uri("https://wibble.com/") },
                new SearchUriBuilderFactory());

            var result = await client.SearchAsync<SearchDissolvedCompaniesRequest, DissolvedCompaniesSearch>(
                new SearchDissolvedCompaniesRequest { Query = "abc", SearchType = "best-match" });

            result.Data.ETag.ShouldBe("etag-1");
            result.Data.Hits.ShouldBe(2);
            result.Data.Kind.ShouldBe("search#dissolved");
            var company = result.Data.Items[0];
            company.CompanyStatus.ShouldBe(CompanyStatus.Dissolved);
            company.DateOfCessation.ShouldBe(new DateTime(2023, 01, 20));
            company.MatchedPreviousCompanyName.Name.ShouldBe("OLD ABC LIMITED");
            company.PreviousCompanyNames[0].CompanyNumber.ShouldBe("01234567");
            company.RegisteredOfficeAddress.Locality.ShouldBe("Cardiff");
            result.Data.TopHit.OrderedAlphaKeyWithId.ShouldBe("ABC DISSOLVED LIMITED:01234567");
        }
    }
}

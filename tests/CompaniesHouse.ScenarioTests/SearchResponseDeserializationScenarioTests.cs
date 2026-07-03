using System.Linq;
using System.Text.Json;
using CompaniesHouse.Response;
using CompaniesHouse.Response.Search.AdvancedCompanySearch;
using CompaniesHouse.Response.Search.AllSearch;
using CompaniesHouse.Response.Search.CompanySearch;
using CompaniesHouse.Response.Search.DissolvedCompaniesSearch;
using CompaniesHouse.Response.Search.OfficerSearch;
using Shouldly;
using Xunit;

namespace CompaniesHouse.ScenarioTests
{
    public class SearchResponseDeserializationScenarioTests
    {
        [Fact]
        public void SearchAllPayload_DeserializesMixedCompanyAndOfficerItems()
        {
            var payload = JsonSerializer.Deserialize<AllSearch>(SearchAllJson, CompaniesHouseJsonSerializerOptions.Default);

            payload.ShouldNotBeNull();
            payload.PageNumber.ShouldBe(1);
            payload.TotalResults.ShouldBe(10000);
            var allItems = payload.Items ?? [];
            allItems.Length.ShouldBe(3);
            allItems[0].ShouldBeOfType<CompaniesHouse.Response.Search.CompanySearch.Company>();
            allItems[2].ShouldBeOfType<CompaniesHouse.Response.Search.OfficerSearch.Officer>();
        }

        [Fact]
        public void CompanySearchPayload_DeserializesAddressSnippetAndExternalRegistrationNumber()
        {
            var payload = JsonSerializer.Deserialize<CompanySearch>(CompanySearchJson, CompaniesHouseJsonSerializerOptions.Default);

            payload.ShouldNotBeNull();
            payload.PageNumber.ShouldBe(1);
            var companies = payload.Companies ?? [];
            companies.Length.ShouldBe(1);
            companies[0].AddressSnippet.ShouldBe("Absa Towers West, 15 Troye Street, Johannesburg, Gauteng 2000, South Africa");
            companies[0].ExternalRegistrationNumber.ShouldBe("198600479406");
            companies[0].DescriptionIdentifier.ShouldBe(["first-uk-establishment-opened-on"]);
            companies[0].Matches?.Snippet.ShouldBeEmpty();
        }

        [Fact]
        public void OfficerSearchPayload_DeserializesPageNumberAndOptionalDateOfBirth()
        {
            var payload = JsonSerializer.Deserialize<OfficerSearch>(OfficerSearchJson, CompaniesHouseJsonSerializerOptions.Default);

            payload.ShouldNotBeNull();
            payload.PageNumber.ShouldBe(1);
            var officers = payload.Officers ?? [];
            officers.Length.ShouldBe(3);
            officers[0].DateOfBirth.ShouldNotBeNull();
            officers[0].DateOfBirth!.Month.ShouldBe(3);
            officers[0].DateOfBirth!.Year.ShouldBe(1947);
            officers[2].DateOfBirth.ShouldBeNull();
        }

        [Fact]
        public void AdvancedCompanySearchPayload_DeserializesOptionalSubtypeAndSicCodes()
        {
            var payload = JsonSerializer.Deserialize<AdvancedCompanySearch>(AdvancedCompanySearchJson, CompaniesHouseJsonSerializerOptions.Default);

            payload.ShouldNotBeNull();
            payload.TopHit?.CompanySubtype.ShouldBeNull();
            var items = payload.Items ?? [];
            items[0].RegisteredOfficeAddress.ShouldNotBeNull();
            items[0].RegisteredOfficeAddress?.AddressLine1.ShouldBeNull();
            items[0].SicCodes.ShouldBeNull();
            items[1].CompanySubtype.ShouldBe(CompanySubtype.CommunityInterestCompany);
            items[1].SicCodes.ShouldBe(["86900"]);
        }

        [Fact]
        public void DissolvedCompaniesPayload_DeserializesSearchTypeSpecificOptionalFields()
        {
            var payload = JsonSerializer.Deserialize<DissolvedCompaniesSearch>(DissolvedCompaniesSearchJson, CompaniesHouseJsonSerializerOptions.Default);

            payload.ShouldNotBeNull();
            payload.Kind.ShouldBe("search#previous-name-dissolved");
            payload.Hits.ShouldBe(932);
            payload.TopHit?.OrderedAlphaKeyWithId.ShouldBeNull();
            payload.TopHit?.MatchedPreviousCompanyName.ShouldNotBeNull();
            payload.TopHit?.MatchedPreviousCompanyName?.Name.ShouldBe("RADIO RENTALS VODAFONE LIMITED");
            payload.TopHit?.RegisteredOfficeAddress.ShouldBeNull();
            (payload.Items ?? []).Single().PreviousCompanyNames.ShouldNotBeNull();
            (payload.Items ?? []).Single().PreviousCompanyNames?.Length.ShouldBe(3);
        }

        private const string SearchAllJson = """
            {
              "items": [
                {
                  "kind": "searchresults#company",
                  "description_identifier": ["dissolved-on"],
                  "company_status": "dissolved",
                  "date_of_creation": "2023-06-23",
                  "date_of_cessation": "2026-05-26",
                  "company_type": "ltd",
                  "company_number": "14957251",
                  "address": {
                    "address_line_1": "Fellows Road",
                    "address_line_2": "Flat 6",
                    "country": "England",
                    "locality": "London",
                    "postal_code": "NW3 3LJ",
                    "premises": "54"
                  },
                  "title": "JOHN LIMITED",
                  "address_snippet": "54 Fellows Road, Flat 6, London, England, NW3 3LJ",
                  "description": "14957251 - Dissolved on 26 May 2026",
                  "links": { "self": "/company/14957251" },
                  "snippet": "",
                  "matches": { "snippet": [] }
                },
                {
                  "kind": "searchresults#company",
                  "description_identifier": ["dissolved-on"],
                  "company_status": "dissolved",
                  "date_of_creation": "2021-10-22",
                  "date_of_cessation": "2023-05-02",
                  "company_type": "ltd",
                  "company_number": "13698801",
                  "address": {
                    "address_line_1": "Beechwood Close",
                    "country": "England",
                    "locality": "Ascot",
                    "postal_code": "SL5 8QJ",
                    "premises": "19"
                  },
                  "title": "JOHN LTD",
                  "address_snippet": "19 Beechwood Close, Ascot, England, SL5 8QJ",
                  "description": "13698801 - Dissolved on 2 May 2023",
                  "links": { "self": "/company/13698801" },
                  "snippet": "",
                  "matches": { "snippet": [] }
                },
                {
                  "kind": "searchresults#officer",
                  "appointment_count": 1,
                  "snippet": "",
                  "description_identifiers": ["appointment-count"],
                  "matches": { "snippet": [] },
                  "title": "JOHN WYATT (FEED FATS) LIMITED",
                  "description": "Total number of appointments 1",
                  "links": { "self": "/officers/WofTSaSTk6iaYlGERAQOdurrDOE/appointments" },
                  "address": {
                    "address_line_1": "Holbeck Lane",
                    "country": "United Kingdom",
                    "locality": "Leeds",
                    "postal_code": "LS11 9XE",
                    "premises": "Braithwaite Street"
                  },
                  "address_snippet": "Braithwaite Street, Holbeck Lane, Leeds, United Kingdom, LS11 9XE"
                }
              ],
              "kind": "search#all",
              "page_number": 1,
              "items_per_page": 5,
              "total_results": 10000,
              "start_index": 0
            }
            """;

        private const string CompanySearchJson = """
            {
              "items": [
                {
                  "kind": "searchresults#company",
                  "description_identifier": ["first-uk-establishment-opened-on"],
                  "company_status": "active",
                  "date_of_creation": "2022-03-01",
                  "external_registration_number": "198600479406",
                  "company_type": "oversea-company",
                  "company_number": "FC040879",
                  "address": {
                    "address_line_1": "15 Troye Street",
                    "country": "South Africa",
                    "locality": "Johannesburg",
                    "premises": "Absa Towers West",
                    "region": "Gauteng 2000"
                  },
                  "title": "ABSA UK PERMANENT ESTABLISHMENT",
                  "address_snippet": "Absa Towers West, 15 Troye Street, Johannesburg, Gauteng 2000, South Africa",
                  "description": "FC040879 - First UK establishment opened on 1 March 2022",
                  "links": { "self": "/company/FC040879" },
                  "snippet": "",
                  "matches": { "snippet": [] }
                }
              ],
              "kind": "search#companies",
              "page_number": 1,
              "items_per_page": 1,
              "total_results": 1,
              "start_index": 0
            }
            """;

        private const string OfficerSearchJson = """
            {
              "items": [
                {
                  "kind": "searchresults#officer",
                  "appointment_count": 75,
                  "snippet": "",
                  "description_identifiers": ["appointment-count", "born-on"],
                  "matches": { "snippet": [] },
                  "title": "Lord Alan Michael SUGAR",
                  "description": "Total number of appointments 75 - Born March 1947",
                  "links": { "self": "/officers/1fox8G7xzfgdlmkfSG5a24fprbM/appointments" },
                  "address": {
                    "address_line_1": "Goldings Hill",
                    "country": "England",
                    "locality": "Loughton",
                    "postal_code": "IG10 2RW",
                    "premises": "Amshold House"
                  },
                  "address_snippet": "Amshold House, Goldings Hill, Loughton, England, IG10 2RW",
                  "date_of_birth": { "month": 3, "year": 1947 }
                },
                {
                  "kind": "searchresults#officer",
                  "appointment_count": 1,
                  "snippet": "",
                  "description_identifiers": ["appointment-count", "born-on"],
                  "matches": { "snippet": [] },
                  "title": "Lord Alan Michael SUGAR",
                  "description": "Total number of appointments 1 - Born March 1947",
                  "links": { "self": "/officers/WjZAkMgKvhRNbn0rXNmOSms8sA0/appointments" },
                  "address": {
                    "address_line_1": "Goldings Hill",
                    "country": "England",
                    "locality": "Loughton",
                    "postal_code": "IG10 2RW",
                    "premises": "Amshold House"
                  },
                  "address_snippet": "Amshold House, Goldings Hill, Loughton, England, IG10 2RW",
                  "date_of_birth": { "month": 3, "year": 1947 }
                },
                {
                  "kind": "searchresults#officer",
                  "appointment_count": 1,
                  "snippet": "",
                  "description_identifiers": ["appointment-count"],
                  "matches": { "snippet": [] },
                  "title": "SUGARMAN INTERNATIONAL LTD",
                  "description": "Total number of appointments 1",
                  "links": { "self": "/officers/Jgko-GXS5n6KtAyggx9VUsuYJP0/appointments" },
                  "address": {
                    "address_line_1": "C/O Srlv",
                    "address_line_2": "1 Conduit Street",
                    "locality": "London",
                    "postal_code": "W1S 2XA"
                  },
                  "address_snippet": "C/O Srlv, 1 Conduit Street, London, W1S 2XA"
                }
              ],
              "kind": "search#officers",
              "page_number": 1,
              "items_per_page": 5,
              "total_results": 10000,
              "start_index": 0
            }
            """;

        private const string AdvancedCompanySearchJson = """
            {
              "etag": "sample",
              "top_hit": {
                "company_name": "TESCO PERSONAL FINANCE LIFE LIMITED",
                "company_number": "SA000044",
                "company_status": "active",
                "company_type": "assurance-company",
                "kind": "search-results#company",
                "links": { "company_profile": "/company/SA000044" },
                "registered_office_address": {}
              },
              "items": [
                {
                  "company_name": "TESCO PERSONAL FINANCE LIFE LIMITED",
                  "company_number": "SA000044",
                  "company_status": "active",
                  "company_type": "assurance-company",
                  "kind": "search-results#company",
                  "links": { "company_profile": "/company/SA000044" },
                  "registered_office_address": {}
                },
                {
                  "company_name": "SKILLS FOR LIFE - LEARNING CENTRE C.I.C",
                  "company_number": "NI066532",
                  "company_status": "dissolved",
                  "company_type": "private-limited-guarant-nsc",
                  "company_subtype": "community-interest-company",
                  "kind": "search-results#company",
                  "links": { "company_profile": "/company/NI066532" },
                  "date_of_cessation": "2019-02-12",
                  "date_of_creation": "2007-10-08",
                  "registered_office_address": {
                    "address_line_1": "18 Knights Green",
                    "address_line_2": "Belfast",
                    "locality": "Co Down",
                    "postal_code": "BT6 9LA"
                  },
                  "sic_codes": ["86900"]
                }
              ],
              "kind": "search#advanced-search",
              "hits": 255
            }
            """;

        private const string DissolvedCompaniesSearchJson = """
            {
              "etag": "sample",
              "top_hit": {
                "company_name": "THORN EMI DATAPHONE LIMITED",
                "company_number": "00368502",
                "company_status": "dissolved",
                "kind": "searchresults#dissolved-company",
                "date_of_cessation": "1994-01-11",
                "date_of_creation": "1941-08-02",
                "previous_company_names": [
                  {
                    "ceased_on": "1985-09-25",
                    "effective_from": "1984-12-04",
                    "name": "RADIO RENTALS VODAFONE LIMITED",
                    "company_number": "00368502"
                  }
                ],
                "matched_previous_company_name": {
                  "ceased_on": "1985-09-25",
                  "effective_from": "1984-12-04",
                  "name": "RADIO RENTALS VODAFONE LIMITED",
                  "company_number": "00368502"
                }
              },
              "items": [
                {
                  "company_name": "THORN EMI DATAPHONE LIMITED",
                  "company_number": "00368502",
                  "company_status": "dissolved",
                  "kind": "searchresults#dissolved-company",
                  "date_of_cessation": "1994-01-11",
                  "date_of_creation": "1941-08-02",
                  "previous_company_names": [
                    {
                      "ceased_on": "1985-09-25",
                      "effective_from": "1984-12-04",
                      "name": "RADIO RENTALS VODAFONE LIMITED",
                      "company_number": "00368502"
                    },
                    {
                      "ceased_on": "1984-12-04",
                      "effective_from": "1984-12-03",
                      "name": "RADIO RENTALS VODAFONE LIMITED",
                      "company_number": "00368502"
                    },
                    {
                      "ceased_on": "1984-12-03",
                      "effective_from": "1941-08-02",
                      "name": "CHARLES MIDLANDS RELAYS LIMITED ",
                      "company_number": "00368502"
                    }
                  ],
                  "matched_previous_company_name": {
                    "ceased_on": "1985-09-25",
                    "effective_from": "1984-12-04",
                    "name": "RADIO RENTALS VODAFONE LIMITED",
                    "company_number": "00368502"
                  }
                }
              ],
              "kind": "search#previous-name-dissolved",
              "hits": 932
            }
            """;
    }
}

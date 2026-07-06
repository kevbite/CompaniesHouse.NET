using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response;
using CompaniesHouse.Response.CompanyProfile;
using CompaniesHouse.Tests.ResourceBuilders;
using CompaniesHouse.UriBuilders;
using Moq;
using Shouldly;
using Xunit;
using CompanyProfile = CompaniesHouse.Response.CompanyProfile.CompanyProfile;

namespace CompaniesHouse.Tests.CompaniesHouseCompanyProfileClientTests
{
    public class CompaniesHouseCompanyProfileClientTests
    {
        private CompaniesHouseCompanyProfileClient _client = null!;

        private CompaniesHouseResponse<Response.CompanyProfile.CompanyProfile> _result = null!;
        private ResourceBuilders.CompanyProfile _companyProfile = null!;

        [Theory]
        [MemberData(nameof(TestCases))]
        public async Task GivenACompaniesHouseCompanyProfileClient_WhenGettingACompanyProfile(CompaniesHouseCompanyProfileClientTestCase testCase)
        {
            _companyProfile = new CompanyProfileBuilder().Build(testCase);
            var resource = new CompanyProfileResourceBuilder(_companyProfile)
                                .Create();

            var uri = new Uri("https://wibble.com/search/companies");

            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);

            var uriBuilder = new Mock<ICompanyProfileUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>()))
                .Returns(uri);

            _client = new CompaniesHouseCompanyProfileClient(new HttpClient(handler), uriBuilder.Object);

            _result = await _client.GetCompanyProfileAsync("abc");

            EquivalencyAssertionExtensions.ShouldBeEquivalentTo((object)_result.Data, _companyProfile);
        }

        [Fact]
        public async Task GivenARealisticPayload_WhenGettingACompanyProfile_ThenNewFieldsAreDeserialized()
        {
            var uri = new Uri("https://wibble.com/company/00445790");
            HttpMessageHandler handler = new StubHttpMessageHandler(uri, TescoCompanyProfileJson);

            var uriBuilder = new Mock<ICompanyProfileUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>()))
                .Returns(uri);

            _client = new CompaniesHouseCompanyProfileClient(new HttpClient(handler), uriBuilder.Object);

            _result = await _client.GetCompanyProfileAsync("00445790");

            _result.StatusCode.ShouldBe(200);
            _result.Data.ShouldNotBeNull();
            _result.Data.CompanyStatus.ShouldBe(CompanyStatus.Active);
            _result.Data.Type.ShouldBe(CompanyType.Plc);
            _result.Data.Jurisdiction.ShouldBe(Jurisdiction.EnglandWales);
            _result.Data.HasSuperSecurePscs.ShouldBe(false);
            _result.Data.Links?.Exemptions.ShouldBe("/company/00445790/exemptions");
        }

        [Fact]
        public async Task GivenA404Response_WhenGettingACompanyProfile_ThenNullDataAndStatusAreReturned()
        {
            var uri = new Uri("https://wibble.com/company/missing");

            var uriBuilder = new Mock<ICompanyProfileUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>()))
                .Returns(uri);

            _client = new CompaniesHouseCompanyProfileClient(new HttpClient(new NotFoundHttpMessageHandler()), uriBuilder.Object);

            _result = await _client.GetCompanyProfileAsync("missing");

            _result.ShouldNotBeNull();
            _result.ShouldBeOfType<CompaniesHouseResponse<CompanyProfile>.NotFound>();
            _result.StatusCode.ShouldBe(404);
        }


        public static IEnumerable<object[]> TestCases()
        {
            var allLastAccountsTypes = EnumerationMappings.PossibleLastAccountsTypes.Keys
                .Select(x => new CompaniesHouseCompanyProfileClientTestCase
                {
                    LastAccountsType = x,
                    CompanyStatus = EnumerationMappings.PossibleCompanyStatuses.Keys.First(),
                    CompanyStatusDetail = EnumerationMappings.PossibleCompanyStatusDetails.Keys.First(),
                    Jurisdiction = EnumerationMappings.PossibleJurisdictions.Keys.First(),
                    Type = EnumerationMappings.ExpectedCompanyTypesMap.Keys.First()
                });

            var allCompanyStatuses = EnumerationMappings.PossibleCompanyStatuses.Keys
                .Select(x => new CompaniesHouseCompanyProfileClientTestCase
                {
                    LastAccountsType = EnumerationMappings.PossibleLastAccountsTypes.Keys.First(),
                    CompanyStatus = x,
                    CompanyStatusDetail = EnumerationMappings.PossibleCompanyStatusDetails.Keys.First(),
                    Jurisdiction = EnumerationMappings.PossibleJurisdictions.Keys.First(),
                    Type = EnumerationMappings.ExpectedCompanyTypesMap.Keys.First()
                });

            var allCompanyStatusDetails = EnumerationMappings.PossibleCompanyStatusDetails.Keys
                .Select(x => new CompaniesHouseCompanyProfileClientTestCase
                {
                    LastAccountsType = EnumerationMappings.PossibleLastAccountsTypes.Keys.First(),
                    CompanyStatus = EnumerationMappings.PossibleCompanyStatuses.Keys.First(),
                    CompanyStatusDetail = x,
                    Jurisdiction = EnumerationMappings.PossibleJurisdictions.Keys.First(),
                    Type = EnumerationMappings.ExpectedCompanyTypesMap.Keys.First()
                });

            var allJurisdictions = EnumerationMappings.PossibleJurisdictions.Keys
                .Select(x => new CompaniesHouseCompanyProfileClientTestCase
                {
                    LastAccountsType = EnumerationMappings.PossibleLastAccountsTypes.Keys.First(),
                    CompanyStatus = EnumerationMappings.PossibleCompanyStatuses.Keys.First(),
                    CompanyStatusDetail = EnumerationMappings.PossibleCompanyStatusDetails.Keys.First(),
                    Jurisdiction = x,
                    Type = EnumerationMappings.ExpectedCompanyTypesMap.Keys.First()
                });

            var allCompanyTypes = EnumerationMappings.ExpectedCompanyTypesMap.Keys
                .Select(x => new CompaniesHouseCompanyProfileClientTestCase
                {
                    LastAccountsType = EnumerationMappings.PossibleLastAccountsTypes.Keys.First(),
                    CompanyStatus = EnumerationMappings.PossibleCompanyStatuses.Keys.First(),
                    CompanyStatusDetail = EnumerationMappings.PossibleCompanyStatusDetails.Keys.First(),
                    Jurisdiction = EnumerationMappings.PossibleJurisdictions.Keys.First(),
                    Type = x
                });

            return allLastAccountsTypes.Concat(allCompanyStatuses)
                .Concat(allCompanyStatusDetails)
                .Concat(allJurisdictions)
                .Concat(allCompanyTypes)
                .Select(testCase => new object[] { testCase });
        }

        private sealed class NotFoundHttpMessageHandler : HttpMessageHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Empty, Encoding.UTF8, "application/json"),
                    ReasonPhrase = "Not Found",
                });
            }
        }

        private const string TescoCompanyProfileJson = """
            {
              "accounts": {"accounting_reference_date": {"day": "26", "month": "02"}, "last_accounts": {"made_up_to": "2025-02-26", "period_end_on": "2025-02-26", "period_start_on": "2024-02-25", "type": "group"}, "next_accounts": {"due_on": "2026-08-26", "overdue": false, "period_end_on": "2026-02-26", "period_start_on": "2025-02-27"}, "next_due": "2026-08-26", "next_made_up_to": "2026-02-26", "overdue": false},
              "can_file": true, "company_name": "TESCO PLC", "company_number": "00445790", "company_status": "active",
              "confirmation_statement": {"last_made_up_to": "2026-06-18", "next_due": "2027-07-02", "next_made_up_to": "2027-06-18", "overdue": false},
              "date_of_creation": "1947-11-27", "etag": "80217136743211b43fe97348238217cf2539d2c9", "has_been_liquidated": false, "has_charges": false, "has_insolvency_history": false,
              "jurisdiction": "england-wales", "last_full_members_list_date": "2013-06-07",
              "links": {"self": "/company/00445790", "charges": "/company/00445790/charges", "filing_history": "/company/00445790/filing-history", "officers": "/company/00445790/officers", "exemptions": "/company/00445790/exemptions"},
              "previous_company_names": [{"ceased_on": "1983-08-25", "effective_from": "1981-12-14", "name": "TESCO STORES (HOLDINGS) PUBLIC LIMITED COMPANY"}, {"ceased_on": "1981-12-14", "effective_from": "1947-11-27", "name": "TESCO STORES (HOLDINGS) LIMITED"}],
              "registered_office_address": {"address_line_1": "Tesco House, Shire Park", "address_line_2": "Kestrel Way", "country": "United Kingdom", "locality": "Welwyn Garden City", "postal_code": "AL7 1GA"},
              "registered_office_is_in_dispute": false, "sic_codes": ["47110"], "type": "plc", "undeliverable_registered_office_address": false, "has_super_secure_pscs": false
            }
            """;
    }
}

using System;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Response.Officers;
using CompaniesHouse.Tests.ResourceBuilders;
using CompaniesHouse.UriBuilders;
using Moq;
using Shouldly;
using Xunit;
using Officers = CompaniesHouse.Response.Officers.Officers;

namespace CompaniesHouse.Tests.CompaniesHouseOfficersTests
{
    public class CompaniesHouseCompanyOfficersClientTests
    {
        private CompaniesHouseOfficersClient _client;

        private CompaniesHouseClientResponse<Officers> _result;
        private ResourceBuilders.Officers _officers;

        [Fact]
        public async Task GivenACompaniesHouseCompanyProfileClient_WhenGettingACompanyProfile()
        {
            _officers = new OfficersBuilder().Build();
            var resource = new OfficersResourceBuilder(_officers).Create();

            var uri = new Uri("https://wibble.com/search/companies");

            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);

            var uriBuilder = new Mock<IOfficersUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), null, null, null))
                .Returns(uri);

            _client = new CompaniesHouseOfficersClient(new HttpClient(handler), uriBuilder.Object);

            _result = await _client.GetOfficersAsync("abc", 0, 25);

            EquivalencyAssertionExtensions.ShouldBeEquivalentTo((object)_result.Data, _officers);
        }

        [Fact]
        public async Task GivenARealCapturedOfficerList_WhenGettingOfficers_ThenMissingLiveFieldsDeserialize()
        {
            var uri = new Uri("https://wibble.com/company/00445790/officers");
            HttpMessageHandler handler = new StubHttpMessageHandler(uri, RealOfficerListJson);

            var uriBuilder = new Mock<IOfficersUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string?>(), It.IsAny<bool?>(), It.IsAny<string?>()))
                .Returns(uri);

            var client = new CompaniesHouseOfficersClient(new HttpClient(handler), uriBuilder.Object);
            var result = await client.GetOfficersAsync("00445790", 0, 5);

            result.Data.ShouldNotBeNull();
            result.Data.ETag.ShouldBe("566e7c60f7de5940734cef04ea94006c91cdbb4a");
            result.Data.ItemsPerPage.ShouldBe(5);
            result.Data.Kind.ShouldBe("officer-list");
            result.Data.InactiveCount.ShouldBe(0);
            result.Data.Links?.Self.ShouldBe("/company/00445790/officers");
            result.Data.TotalResults.ShouldBe(74);
            result.Data.Items.Length.ShouldBe(2);

            var officer = result.Data.Items[1];
            officer.ETag.ShouldBe("5ad20f5a7c2d801107af20d5f413ab70bc0a3175");
            officer.PersonNumber.ShouldBe("248450070003");
            officer.IsPre1992Appointment.ShouldBe(false);
            officer.OfficerRole.ShouldBe(OfficerRole.Director);
            officer.OfficerId.ShouldBe("aqrS_F-2zIvSaMNtl1opqDV4-w0");
            officer.Links?.Self.ShouldBe("/company/00445790/appointments/gE7Pw_lx4HWJvqSfwqudfusS9Ig");
            officer.IdentityVerificationDetails.ShouldNotBeNull();
            officer.IdentityVerificationDetails.AntiMoneyLaunderingSupervisoryBodies.ShouldBe(
                ["Faculty Office of the Archbishop of Canterbury (FO)"]);
            officer.IdentityVerificationDetails.AppointmentVerificationStartOn.ShouldBe(new DateTime(2026, 07, 01));
            officer.IdentityVerificationDetails.AppointmentVerificationEndOn.ShouldBe(new DateTime(9999, 12, 31));
            officer.IdentityVerificationDetails.AuthorisedCorporateServiceProviderName.ShouldBe("DE PINNA LLP ACSP");
            officer.IdentityVerificationDetails.IdentityVerifiedOn.ShouldBe(new DateTime(2025, 07, 29));
            officer.IdentityVerificationDetails.PreferredName.ShouldBe("Melissa Bethell");
        }

        [Fact]
        public async Task GivenARealCapturedCorporateOfficerList_WhenGettingOfficers_ThenIdentificationTypeDeserializes()
        {
            var uri = new Uri("https://wibble.com/company/03610056/officers");
            HttpMessageHandler handler = new StubHttpMessageHandler(uri, RealCorporateOfficerListJson);

            var uriBuilder = new Mock<IOfficersUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string?>(), It.IsAny<bool?>(), It.IsAny<string?>()))
                .Returns(uri);

            var client = new CompaniesHouseOfficersClient(new HttpClient(handler), uriBuilder.Object);
            var result = await client.GetOfficersAsync("03610056", 0, 1);

            result.Data.ShouldNotBeNull();
            result.Data.Items.Length.ShouldBe(1);
            result.Data.Items[0].Identification.ShouldNotBeNull();
            result.Data.Items[0].OfficerRole.ShouldBe(OfficerRole.CorporateSecretary);
            result.Data.Items[0].Identification.IdentificationType.ShouldBe(IdentificationType.UkLimitedCompany);
            result.Data.Items[0].Identification.RegistrationNumber.ShouldBe("3849195");
            result.Data.Items[0].OfficerId.ShouldBe("YwIOmduyS6PW5axJgQQrsTGyRD0");
        }

        private const string RealOfficerListJson = """
            {
              "active_count": 11,
              "etag": "566e7c60f7de5940734cef04ea94006c91cdbb4a",
              "items": [
                {
                  "etag": "566e7c60f7de5940734cef04ea94006c91cdbb4a",
                  "address": {"address_line_1": "Tesco House, Shire Park", "address_line_2": "Kestrel Way", "country": "United Kingdom", "locality": "Welwyn Garden City", "postal_code": "AL7 1GA"},
                  "appointed_on": "2025-04-14",
                  "is_pre_1992_appointment": false,
                  "links": {"self": "/company/00445790/appointments/lnfNdAqKHBZCL2akA7SXLkkA8KI", "officer": {"appointments": "/officers/uJ_F_UGCbPiYELlJ_fHc-J_goqo/appointments"}},
                  "name": "TAYLOR, Christopher Jon",
                  "officer_role": "secretary",
                  "person_number": "334718260001"
                },
                {
                  "etag": "5ad20f5a7c2d801107af20d5f413ab70bc0a3175",
                  "address": {"address_line_1": "Shire Park", "address_line_2": "Kestrel Way", "country": "United Kingdom", "locality": "Welwyn Garden City", "postal_code": "AL7 1GA", "premises": "Tesco House"},
                  "appointed_on": "2018-09-24",
                  "is_pre_1992_appointment": false,
                  "country_of_residence": "United Kingdom",
                  "date_of_birth": {"month": 9, "year": 1974},
                  "links": {"self": "/company/00445790/appointments/gE7Pw_lx4HWJvqSfwqudfusS9Ig", "officer": {"appointments": "/officers/aqrS_F-2zIvSaMNtl1opqDV4-w0/appointments"}},
                  "name": "BETHELL, Melissa",
                  "nationality": "British",
                  "officer_role": "director",
                  "person_number": "248450070003",
                  "identity_verification_details": {
                    "anti_money_laundering_supervisory_bodies": ["Faculty Office of the Archbishop of Canterbury (FO)"],
                    "appointment_verification_end_on": "9999-12-31",
                    "appointment_verification_start_on": "2026-07-01",
                    "authorised_corporate_service_provider_name": "DE PINNA LLP ACSP",
                    "identity_verified_on": "2025-07-29",
                    "preferred_name": "Melissa Bethell"
                  }
                }
              ],
              "items_per_page": 5,
              "kind": "officer-list",
              "links": {"self": "/company/00445790/officers"},
              "resigned_count": 63,
              "inactive_count": 0,
              "start_index": 0,
              "total_results": 74
            }
            """;

        private const string RealCorporateOfficerListJson = """
            {
              "active_count": 1,
              "etag": "b0f14fcd8f8a9cfd6789dbdcbdb2c08b7fbf84e4",
              "items": [
                {
                  "etag": "b0f14fcd8f8a9cfd6789dbdcbdb2c08b7fbf84e4",
                  "address": {"address_line_1": "Howick Place", "country": "United Kingdom", "locality": "London", "postal_code": "SW1P 1WG", "premises": "5"},
                  "appointed_on": "2021-12-31",
                  "is_pre_1992_appointment": false,
                  "links": {"self": "/company/03610056/appointments/4F3DS_j7LgOTlBEE2xIfmM7wGhs", "officer": {"appointments": "/officers/YwIOmduyS6PW5axJgQQrsTGyRD0/appointments"}},
                  "name": "INFORMA COSEC LIMITED",
                  "officer_role": "corporate-secretary",
                  "identification": {"identification_type": "uk-limited-company", "registration_number": "3849195"},
                  "person_number": "279172060001"
                }
              ],
              "items_per_page": 1,
              "kind": "officer-list",
              "links": {"self": "/company/03610056/officers"},
              "resigned_count": 0,
              "inactive_count": 0,
              "start_index": 0,
              "total_results": 1
            }
            """;
    }
}

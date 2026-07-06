using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Response.Officers;
using CompaniesHouse.Tests.ResourceBuilders;
using CompaniesHouse.UriBuilders;
using Moq;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.CompaniesHouseOfficersAppointmentClientTests
{
    public class CompaniesHouseOfficersAppointmentClientTests
    {

        [Theory]
        [MemberData(nameof(TestCases))]
        public async Task GivenACompaniesHouseOffficerAppointmentClient_WhenGettingAnOfficerByAppointmentId(CompaniesHouseOfficerByAppointmentTestCase testCase)
        {
            var officersAppointment = OfficerBuilder.Build(testCase);
            var resource = OfficersResourceBuilder.CreateSingle(officersAppointment);

            var uri = new Uri("https://wibble.com/company/wobble/registered-office-address");

            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);

            var uriBuilder = new Mock<IOfficersAppointmentUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<string>())).Returns(uri);

            var client = new CompaniesHouseOfficerByByAppointmentClient(new HttpClient(handler), uriBuilder.Object);
            var result = await client.GetOfficerByAppointmentIdAsync("abc", "1");

            EquivalencyAssertionExtensions.ShouldBeEquivalentTo((object)result.Data, officersAppointment);
        }

        public static IEnumerable<object[]> TestCases() =>
            EnumerationMappings.PossibleOfficerRoles.Keys
                .Select(x => new CompaniesHouseOfficerByAppointmentTestCase
                {
                    OfficerRole = x
                })
                .Select(testCase => new object[] { testCase });

        [Fact]
        public async Task GivenARealCapturedAppointment_WhenGettingAnOfficerByAppointmentId_ThenListShapeFieldsDeserialize()
        {
            var uri = new Uri("https://wibble.com/company/00445790/appointments/gE7Pw_lx4HWJvqSfwqudfusS9Ig");
            HttpMessageHandler handler = new StubHttpMessageHandler(uri, RealAppointmentJson);

            var uriBuilder = new Mock<IOfficersAppointmentUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<string>())).Returns(uri);

            var client = new CompaniesHouseOfficerByByAppointmentClient(new HttpClient(handler), uriBuilder.Object);
            var result = await client.GetOfficerByAppointmentIdAsync("00445790", "gE7Pw_lx4HWJvqSfwqudfusS9Ig");

            result.Data.ShouldNotBeNull();
            result.Data.ETag.ShouldBe("5ad20f5a7c2d801107af20d5f413ab70bc0a3175");
            result.Data.OfficerRole.ShouldBe(OfficerRole.Director);
            result.Data.PersonNumber.ShouldBe("248450070003");
            result.Data.IsPre1992Appointment.ShouldBe(false);
            result.Data.Links?.Self.ShouldBe("/company/00445790/appointments/gE7Pw_lx4HWJvqSfwqudfusS9Ig");
            result.Data.OfficerId.ShouldBe("aqrS_F-2zIvSaMNtl1opqDV4-w0");
            result.Data.IdentityVerificationDetails.ShouldNotBeNull();
            result.Data.IdentityVerificationDetails.AppointmentVerificationEndOn.ShouldBe(new DateTime(9999, 12, 31));
            result.Data.IdentityVerificationDetails.PreferredName.ShouldBe("Melissa Bethell");
        }

        private const string RealAppointmentJson = """
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
            """;
    }

}
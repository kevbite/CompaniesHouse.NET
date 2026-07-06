using System;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Response;
using CompaniesHouse.Response.Appointments;
using CompaniesHouse.UriBuilders;
using Moq;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.CompaniesHouseAppointmentsClientTests
{
    public class CompaniesHouseAppointmentsClientTests
    {
        [Fact]
        public async Task GivenARealCapturedAppointmentList_WhenGettingAppointments_ThenEnvelopeAndItemsDeserialize()
        {
            const string json = """
                {
                  "active_count":0,
                  "date_of_birth":{"month":8,"year":1973},
                  "etag":"bdc01ed926045d56901268825b5c58ec21b8754b",
                  "inactive_count":0,
                  "is_corporate_officer":false,
                  "items":[
                    {
                      "address":{"address_line_1":"555 Bryant Street 163","address_line_2":"Palo Alto","locality":"California","postal_code":"94301"},
                      "appointed_on":"2000-09-27",
                      "appointed_to":{"company_name":"GOOGLE UK LIMITED","company_number":"03977902","company_status":"active"},
                      "name":"Sergey BRIN",
                      "is_pre_1992_appointment":false,
                      "links":{"company":"/company/03977902"},
                      "name_elements":{"forename":"Sergey","surname":"BRIN"},
                      "nationality":"Usa",
                      "officer_role":"director",
                      "resigned_on":"2004-08-04"
                    }
                  ],
                  "items_per_page":5,
                  "kind":"personal-appointment",
                  "links":{"self":"/officers/uQNQ-blSo-8PiOaehWClTPmbZNI/appointments"},
                  "name":"Sergey BRIN",
                  "resigned_count":1,
                  "start_index":0,
                  "total_results":1
                }
                """;

            var uri = new Uri("https://wibble.com/officers/officer-id/appointments");
            HttpMessageHandler handler = new StubHttpMessageHandler(uri, json);
            var uriBuilder = new Mock<IAppointmentsUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(uri);

            var client = new CompaniesHouseAppointmentsClient(new HttpClient(handler), uriBuilder.Object);
            var result = await client.GetAppointmentsAsync("officer-id", 0, 5, default);

            result.Data.ShouldNotBeNull();
            result.Data.Kind.ShouldBe("personal-appointment");
            result.Data.Links?.Self.ShouldBe("/officers/uQNQ-blSo-8PiOaehWClTPmbZNI/appointments");
            result.Data.DateOfBirth?.Year.ShouldBe(1973);
            result.Data.Items.ShouldNotBeNull();
            result.Data.Items[0].Appointed?.CompanyStatus.ShouldBe(CompanyStatus.Active);
            result.Data.Items[0].Links?.Company.ShouldBe("/company/03977902");
            result.Data.Items[0].OfficerRole.ShouldBe(CompaniesHouse.Response.Officers.OfficerRole.Director);
        }

        [Fact]
        public async Task GivenARealCapturedCorporateAppointmentList_WhenGettingAppointments_ThenCorporateIdentificationDeserializes()
        {
            const string json = """
                {
                  "active_count":90,
                  "etag":"8a276751f22df1b08704b544645a41b00fc0fec1",
                  "inactive_count":19,
                  "is_corporate_officer":true,
                  "items":[
                    {
                      "address":{"address_line_1":"Howick Place","country":"United Kingdom","locality":"London","postal_code":"SW1P 1WG","premises":"5"},
                      "appointed_on":"2025-10-21",
                      "appointed_to":{"company_name":"INFORMA PRESTIGE HOLDINGS LIMITED","company_number":"16718313","company_status":"active"},
                      "name":"INFORMA COSEC LIMITED",
                      "identification":{"identification_type":"uk-limited-company","registration_number":"3849195"},
                      "is_pre_1992_appointment":false,
                      "links":{"company":"/company/16718313"},
                      "officer_role":"corporate-secretary"
                    }
                  ],
                  "items_per_page":5,
                  "kind":"personal-appointment",
                  "links":{"self":"/officers/YwIOmduyS6PW5axJgQQrsTGyRD0/appointments"},
                  "name":"INFORMA COSEC LIMITED",
                  "resigned_count":12,
                  "start_index":0,
                  "total_results":121
                }
                """;

            var uri = new Uri("https://wibble.com/officers/corporate-id/appointments");
            HttpMessageHandler handler = new StubHttpMessageHandler(uri, json);
            var uriBuilder = new Mock<IAppointmentsUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(uri);

            var client = new CompaniesHouseAppointmentsClient(new HttpClient(handler), uriBuilder.Object);
            var result = await client.GetAppointmentsAsync("corporate-id", 0, 5, default);

            result.Data.ShouldNotBeNull();
            result.Data.IsCorporateOfficer.ShouldBeTrue();
            result.Data.Items.ShouldNotBeNull();
            result.Data.Items[0].Identification?.RegistrationNumber.ShouldBe("3849195");
            result.Data.Items[0].OfficerRole.ShouldBe(CompaniesHouse.Response.Officers.OfficerRole.CorporateSecretary);
        }
    }
}

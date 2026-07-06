using System.Text.Json;
using CompaniesHouse.Response.Appointments;
using CompaniesHouse.Response.PersonsWithSignificantControl;
using Shouldly;
using Xunit;

namespace CompaniesHouse.ScenarioTests
{
    public class AppointmentsAndPscScenarios
    {
        [Fact]
        public void Appointments_DeserializesCorporateAndEnvelopeFields()
        {
            const string json = """
                {
                  "active_count":90,
                  "etag":"8a276751f22df1b08704b544645a41b00fc0fec1",
                  "inactive_count":19,
                  "is_corporate_officer":true,
                  "items":[
                    {
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

            var value = JsonSerializer.Deserialize<Appointments>(json, CompaniesHouseJsonSerializerOptions.Default);
            var items = value?.Items ?? [];

            value.ShouldNotBeNull();
            value.IsCorporateOfficer.ShouldBeTrue();
            items.ShouldNotBeEmpty();
            items[0].Identification?.RegistrationNumber.ShouldBe("3849195");
        }

        [Fact]
        public void PersonsWithSignificantControl_DeserializesCorporateEntityList()
        {
            const string json = """
                {
                  "items_per_page":10,
                  "items":[
                    {
                      "notified_on":"2016-04-06",
                      "name":"Alphabet, Inc.",
                      "links":{"self":"/company/03977902/persons-with-significant-control/corporate-entity/cdqMtbUIfvMc4RgPpHEhBM8trCs"},
                      "identification":{"legal_form":"Corporate","legal_authority":"Delaware Secretary Of State","country_registered":"Delaware","place_registered":"Delaware","registration_number":"5786925"},
                      "ceased":false,
                      "kind":"corporate-entity-person-with-significant-control",
                      "natures_of_control":["ownership-of-shares-75-to-100-percent","voting-rights-75-to-100-percent","right-to-appoint-and-remove-directors"]
                    }
                  ],
                  "start_index":0,
                  "total_results":1,
                  "active_count":1,
                  "ceased_count":0,
                  "links":{"self":"/company/03977902/persons-with-significant-control"}
                }
                """;

            var value = JsonSerializer.Deserialize<PersonsWithSignificantControl>(json, CompaniesHouseJsonSerializerOptions.Default);
            var items = value?.Items ?? [];

            value.ShouldNotBeNull();
            value.TotalResults.ShouldBe(1);
            items.ShouldNotBeEmpty();
            items[0].Kind.ShouldBe(new PersonWithSignificantControlKind("corporate-entity-person-with-significant-control"));
            (items[0].NaturesOfControl ?? []).ShouldContain(new PersonWithSignificantControlNatureOfControl("right-to-appoint-and-remove-directors"));
        }
    }
}

using System;
using System.Text.Json;
using CompaniesHouse.Response.Officers;
using Shouldly;
using Xunit;

namespace CompaniesHouse.ScenarioTests
{
    public class OfficersDeserializationScenarioTests
    {
        [Fact]
        public void OfficerList_DeserializesConfirmedListEnvelopeAndIdentityVerificationDetails()
        {
            var officers = JsonSerializer.Deserialize<Officers>(OfficerListJson, CompaniesHouseJsonSerializerOptions.Default);

            officers.ShouldNotBeNull();
            officers.ETag.ShouldBe("566e7c60f7de5940734cef04ea94006c91cdbb4a");
            officers.ItemsPerPage.ShouldBe(5);
            officers.Kind.ShouldBe("officer-list");
            officers.Links?.Self.ShouldBe("/company/00445790/officers");
            officers.TotalResults.ShouldBe(74);
            officers.Items.Length.ShouldBe(2);
            officers.Items[1].OfficerRole.ShouldBe(OfficerRole.Director);
            officers.Items[1].PersonNumber.ShouldBe("248450070003");
            officers.Items[1].OfficerId.ShouldBe("aqrS_F-2zIvSaMNtl1opqDV4-w0");
            officers.Items[1].IdentityVerificationDetails?.AppointmentVerificationEndOn.ShouldBe(new DateTime(9999, 12, 31));
        }

        [Fact]
        public void OfficerAppointment_DeserializesUsingTheSharedOfficerShape()
        {
            var officer = JsonSerializer.Deserialize<Officer>(OfficerAppointmentJson, CompaniesHouseJsonSerializerOptions.Default);

            officer.ShouldNotBeNull();
            officer.ETag.ShouldBe("5ad20f5a7c2d801107af20d5f413ab70bc0a3175");
            officer.OfficerRole.ShouldBe(OfficerRole.Director);
            officer.PersonNumber.ShouldBe("248450070003");
            officer.IsPre1992Appointment.ShouldBe(false);
            officer.OfficerId.ShouldBe("aqrS_F-2zIvSaMNtl1opqDV4-w0");
            officer.IdentityVerificationDetails?.PreferredName.ShouldBe("Melissa Bethell");
        }

        [Fact]
        public void CorporateOfficerList_DeserializesIdentificationType()
        {
            var officers = JsonSerializer.Deserialize<Officers>(CorporateOfficerListJson, CompaniesHouseJsonSerializerOptions.Default);

            officers.ShouldNotBeNull();
            officers.Items.Length.ShouldBe(1);
            officers.Items[0].OfficerRole.ShouldBe(OfficerRole.CorporateSecretary);
            officers.Items[0].Identification.ShouldNotBeNull();
            officers.Items[0].Identification!.IdentificationType.ShouldBe(IdentificationType.UkLimitedCompany);
            officers.Items[0].Identification!.RegistrationNumber.ShouldBe("3849195");
        }

        private const string OfficerListJson = """
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

        private const string OfficerAppointmentJson = """
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

        private const string CorporateOfficerListJson = """
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

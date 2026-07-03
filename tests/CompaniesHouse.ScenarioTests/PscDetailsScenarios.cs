using System;
using System.Text.Json;
using CompaniesHouse.Response.PersonsWithSignificantControl;
using Shouldly;
using Xunit;

namespace CompaniesHouse.ScenarioTests
{
    public class PscDetailsScenarios
    {
        [Fact]
        public void IndividualPscDetail_DeserializesObservedFields()
        {
            var value = JsonSerializer.Deserialize<PersonWithSignificantControl>(IndividualJson, CompaniesHouseJsonSerializerOptions.Default);

            value.ShouldNotBeNull();
            value.Kind.ShouldBe(new PersonWithSignificantControlKind("individual-person-with-significant-control"));
            value.Name.ShouldBe("Chris Brown");
            value.DateOfBirth?.Year.ShouldBe(1979);
            (value.NaturesOfControl ?? []).ShouldContain(new PersonWithSignificantControlNatureOfControl("ownership-of-shares-25-to-50-percent"));
        }

        [Fact]
        public void PscStatementList_DeserializesEnvelopeAndStatement()
        {
            var value = JsonSerializer.Deserialize<PersonsWithSignificantControlStatements>(StatementListJson, CompaniesHouseJsonSerializerOptions.Default);

            value.ShouldNotBeNull();
            value.TotalResults.ShouldBe(1);
            value.Items.Length.ShouldBe(1);
            value.Items[0].Statement.ShouldBe("psc-has-failed-to-confirm-changed-details");
            value.Items[0].NotifiedOn.ShouldBe(new DateTime(2016, 6, 30));
        }

        [Fact]
        public void SuperSecurePsc_DeserializesStatementDates()
        {
            var value = JsonSerializer.Deserialize<SuperSecurePersonWithSignificantControl>(SuperSecureJson, CompaniesHouseJsonSerializerOptions.Default);

            value.ShouldNotBeNull();
            value.Kind.ShouldBe("super-secure-person-with-significant-control");
            value.Description.ShouldBe("super-secure-person-with-significant-control");
            value.IdentityVerificationDetails.ShouldNotBeNull();
            value.IdentityVerificationDetails.AppointmentVerificationStatementDate.ShouldBe(new DateTime(2026, 7, 1));
            value.IdentityVerificationDetails.AppointmentVerificationStatementDueOn.ShouldBe(new DateTime(2026, 9, 1));
        }

        private const string IndividualJson = """
            {
              "etag":"ef3d935f77e2f6b1dfacf1f3f7289a594f16f8e1",
              "notified_on":"2019-01-16",
              "kind":"individual-person-with-significant-control",
              "country_of_residence":"United Kingdom",
              "date_of_birth":{"month":7,"year":1979},
              "name":"Chris Brown",
              "name_elements":{"forename":"Chris","surname":"Brown"},
              "links":{"self":"/company/11790215/persons-with-significant-control/individual/SGX6zLwNkq2YrjsYXPSVnmYi6SE"},
              "nationality":"British",
              "address":{"address_line_1":"1 Street","locality":"London","postal_code":"W1A 1AA"},
              "natures_of_control":["ownership-of-shares-25-to-50-percent"]
            }
            """;

        private const string StatementListJson = """
            {
              "items_per_page":25,
              "items":[
                {
                  "etag":"95ca7497819e5fbc1144b6a3ef09f477228f3f5f",
                  "kind":"persons-with-significant-control-statement",
                  "notified_on":"2016-06-30",
                  "statement":"psc-has-failed-to-confirm-changed-details",
                  "links":{
                    "self":"/company/05124262/persons-with-significant-control-statements/8xxEeFpu5Xmpf1ce1FmwM-sK8J8",
                    "person_with_significant_control":"/company/05124262/persons-with-significant-control/individual/KdK4nMdcYtuJV_Ax0s8_5JJmQdw"
                  }
                }
              ],
              "start_index":0,
              "total_results":1,
              "active_count":1,
              "ceased_count":0,
              "links":{"self":"/company/05124262/persons-with-significant-control-statements"}
            }
            """;

        private const string SuperSecureJson = """
            {
              "etag":"fa0f4f2a1b8186f26bc65820c7a66ab6cf05b43e",
              "kind":"super-secure-person-with-significant-control",
              "description":"super-secure-person-with-significant-control",
              "identity_verification_details":{
                "appointment_verification_statement_date":"2026-07-01",
                "appointment_verification_statement_due_on":"2026-09-01"
              },
              "links":{"self":"/company/1/persons-with-significant-control/super-secure/2"}
            }
            """;
    }
}

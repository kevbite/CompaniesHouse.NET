using System;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Response.PersonsWithSignificantControl;
using CompaniesHouse.UriBuilders;
using Moq;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.CompaniesHousePersonsWithSignificantControlDetailsClientTests
{
    public class CompaniesHousePersonsWithSignificantControlDetailsClientTests
    {
        [Fact]
        public async Task GivenCapturedIndividualDetail_WhenGettingIndividual_ThenObservedFieldsDeserialize()
        {
            var uri = new Uri("https://wibble.com/company/11790215/persons-with-significant-control/individual/1");
            HttpMessageHandler handler = new StubHttpMessageHandler(uri, IndividualJson);
            var uriBuilder = CreateUriBuilder(uri);

            var client = new CompaniesHousePersonsWithSignificantControlDetailsClient(new HttpClient(handler), uriBuilder.Object);
            var result = await client.GetIndividualPersonWithSignificantControlAsync("11790215", "1");

            result.Data.Kind.ShouldBe(new PersonWithSignificantControlKind("individual-person-with-significant-control"));
            result.Data.Name.ShouldBe("Chris Brown");
            result.Data.Links?.Self.ShouldBe("/company/11790215/persons-with-significant-control/individual/SGX6zLwNkq2YrjsYXPSVnmYi6SE");
            (result.Data.NaturesOfControl ?? []).ShouldContain(new PersonWithSignificantControlNatureOfControl("ownership-of-shares-25-to-50-percent"));
        }

        [Fact]
        public async Task GivenCapturedStatementList_WhenGettingStatementsList_ThenEnvelopeAndItemsDeserialize()
        {
            var uri = new Uri("https://wibble.com/company/05124262/persons-with-significant-control-statements");
            HttpMessageHandler handler = new StubHttpMessageHandler(uri, StatementListJson);
            var uriBuilder = CreateUriBuilder(uri);

            var client = new CompaniesHousePersonsWithSignificantControlDetailsClient(new HttpClient(handler), uriBuilder.Object);
            var result = await client.GetPersonsWithSignificantControlStatementsAsync("05124262", 0, 25);

            result.Data.TotalResults.ShouldBe(1);
            result.Data.Items.Length.ShouldBe(1);
            result.Data.Items[0].Statement.ShouldBe("psc-has-failed-to-confirm-changed-details");
            result.Data.Items[0].Links.Self.ShouldBe("/company/05124262/persons-with-significant-control-statements/8xxEeFpu5Xmpf1ce1FmwM-sK8J8");
        }

        [Fact]
        public async Task GivenCapturedSuperSecure_WhenGettingSuperSecurePsc_ThenObservedFieldsDeserialize()
        {
            var uri = new Uri("https://wibble.com/company/1/persons-with-significant-control/super-secure/2");
            HttpMessageHandler handler = new StubHttpMessageHandler(uri, SuperSecureJson);
            var uriBuilder = CreateUriBuilder(uri);

            var client = new CompaniesHousePersonsWithSignificantControlDetailsClient(new HttpClient(handler), uriBuilder.Object);
            var result = await client.GetSuperSecurePersonWithSignificantControlAsync("1", "2");

            result.Data.Kind.ShouldBe("super-secure-person-with-significant-control");
            result.Data.Description.ShouldBe("super-secure-person-with-significant-control");
            result.Data.Links.Self.ShouldBe("/company/1/persons-with-significant-control/super-secure/2");
            result.Data.IdentityVerificationDetails.ShouldNotBeNull();
            result.Data.IdentityVerificationDetails.AppointmentVerificationStatementDate.ShouldBe(new DateTime(2026, 7, 1));
        }

        private static Mock<IPersonsWithSignificantControlDetailsUriBuilder> CreateUriBuilder(Uri uri)
        {
            var uriBuilder = new Mock<IPersonsWithSignificantControlDetailsUriBuilder>();
            uriBuilder.Setup(x => x.BuildIndividual(It.IsAny<string>(), It.IsAny<string>())).Returns(uri);
            uriBuilder.Setup(x => x.BuildIndividualBeneficialOwner(It.IsAny<string>(), It.IsAny<string>())).Returns(uri);
            uriBuilder.Setup(x => x.BuildCorporateEntity(It.IsAny<string>(), It.IsAny<string>())).Returns(uri);
            uriBuilder.Setup(x => x.BuildCorporateEntityBeneficialOwner(It.IsAny<string>(), It.IsAny<string>())).Returns(uri);
            uriBuilder.Setup(x => x.BuildLegalPerson(It.IsAny<string>(), It.IsAny<string>())).Returns(uri);
            uriBuilder.Setup(x => x.BuildLegalPersonBeneficialOwner(It.IsAny<string>(), It.IsAny<string>())).Returns(uri);
            uriBuilder.Setup(x => x.BuildStatementsList(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool?>())).Returns(uri);
            uriBuilder.Setup(x => x.BuildStatement(It.IsAny<string>(), It.IsAny<string>())).Returns(uri);
            uriBuilder.Setup(x => x.BuildSuperSecure(It.IsAny<string>(), It.IsAny<string>())).Returns(uri);
            uriBuilder.Setup(x => x.BuildSuperSecureBeneficialOwner(It.IsAny<string>(), It.IsAny<string>())).Returns(uri);
            return uriBuilder;
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

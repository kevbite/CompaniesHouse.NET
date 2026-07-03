using System;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.UriBuilders;
using Moq;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.CompaniesHouseDisqualifiedOfficerDetailsClientTests
{
    public class CompaniesHouseDisqualifiedOfficerDetailsClientTests
    {
        [Fact]
        public async Task GivenCapturedNaturalPayload_WhenGettingNaturalDisqualification_ThenObservedFieldsDeserialize()
        {
            var uri = new Uri("https://wibble.com/disqualified-officers/natural/1");
            HttpMessageHandler handler = new StubHttpMessageHandler(uri, NaturalJson);
            var uriBuilder = new Mock<IDisqualifiedOfficerUriBuilder>();
            uriBuilder.Setup(x => x.BuildNatural(It.IsAny<string>())).Returns(uri);
            uriBuilder.Setup(x => x.BuildCorporate(It.IsAny<string>())).Returns(uri);

            var client = new CompaniesHouseDisqualifiedOfficerDetailsClient(new HttpClient(handler), uriBuilder.Object);
            var result = await client.GetNaturalDisqualificationAsync("1");

            result.Data.Kind.ShouldBe("natural-disqualification");
            result.Data.Surname.ShouldBe("HENRY  (AKA KEVIN GREGORY)");
            result.Data.Links.Self.ShouldBe("/disqualified-officers/natural/iJZbzhXjhanBiPC9LRVC-FfaRqg");
            result.Data.Disqualifications.Length.ShouldBe(1);
            result.Data.Disqualifications[0].DisqualificationType.ShouldBe("court-order");
            result.Data.Disqualifications[0].Reason.DescriptionIdentifier.ShouldBe("investigation-of-company");
        }

        [Fact]
        public async Task GivenCapturedCorporatePayload_WhenGettingCorporateDisqualification_ThenObservedFieldsDeserialize()
        {
            var uri = new Uri("https://wibble.com/disqualified-officers/corporate/1");
            HttpMessageHandler handler = new StubHttpMessageHandler(uri, CorporateJson);
            var uriBuilder = new Mock<IDisqualifiedOfficerUriBuilder>();
            uriBuilder.Setup(x => x.BuildCorporate(It.IsAny<string>())).Returns(uri);
            uriBuilder.Setup(x => x.BuildNatural(It.IsAny<string>())).Returns(uri);

            var client = new CompaniesHouseDisqualifiedOfficerDetailsClient(new HttpClient(handler), uriBuilder.Object);
            var result = await client.GetCorporateDisqualificationAsync("1");

            result.Data.Kind.ShouldBe("corporate-disqualification");
            result.Data.Name.ShouldBe("LIMITED LIABILITY COMPANY BANK TOCHKA");
            result.Data.Links.Self.ShouldBe("/disqualified-officers/corporate/XzsV1VeAiawcC6ntn1BRavuZdDA");
            result.Data.Disqualifications.Length.ShouldBe(1);
            result.Data.Disqualifications[0].DisqualificationType.ShouldBe("sanction");
            result.Data.Disqualifications[0].Reason.Act.ShouldBe("sanctions-anti-money-laundering-act-2018");
        }

        private const string NaturalJson = """
            {
              "date_of_birth": "1968-06-18",
              "person_number": "260506620001",
              "etag": "718b494f50cef7c55484c965a77c6c660dab3925",
              "kind": "natural-disqualification",
              "forename": "Charles",
              "surname": "HENRY  (AKA KEVIN GREGORY)",
              "title": "Mr",
              "links": {
                "self": "/disqualified-officers/natural/iJZbzhXjhanBiPC9LRVC-FfaRqg"
              },
              "disqualifications": [
                {
                  "case_identifier": "CR-2018-002193",
                  "address": {
                    "address_line_1": "Parkway",
                    "country": "United Kingdom",
                    "locality": "Romford",
                    "postal_code": "RM2 5NT",
                    "premises": "19",
                    "region": "Essex"
                  },
                  "company_names": [
                    "LEGAL ACTION ALSO KNOWN AS CHARLES HENRY",
                    "CHARLES HENRY AND CO"
                  ],
                  "court_name": "Business And Property Courts London",
                  "disqualification_type": "court-order",
                  "disqualified_from": "2019-07-18",
                  "disqualified_until": "2029-07-17",
                  "heard_on": "2019-06-27",
                  "reason": {
                    "act": "company-directors-disqualification-act-1986",
                    "section": "8",
                    "description_identifier": "investigation-of-company"
                  }
                }
              ]
            }
            """;

        private const string CorporateJson = """
            {
              "person_number": "345902060001",
              "etag": "8cf5a48f40f6a7b60adc6d6d24306f09ad0d1bec",
              "kind": "corporate-disqualification",
              "name": "LIMITED LIABILITY COMPANY BANK TOCHKA",
              "links": {
                "self": "/disqualified-officers/corporate/XzsV1VeAiawcC6ntn1BRavuZdDA"
              },
              "disqualifications": [
                {
                  "case_identifier": "RUS3405",
                  "address": {
                    "address_line_1": "3rd Krutitsky",
                    "country": "Russia",
                    "postal_code": "109044",
                    "premises": "7n Pomeshch 11",
                    "region": "Moscow"
                  },
                  "disqualification_type": "sanction",
                  "disqualified_from": "2026-02-24",
                  "disqualified_until": "9999-12-31",
                  "reason": {
                    "act": "sanctions-anti-money-laundering-act-2018",
                    "section": "3A",
                    "description_identifier": "disqualification-under-sanctions-regulation"
                  }
                }
              ]
            }
            """;
    }
}

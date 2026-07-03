using System;
using System.Text.Json;
using CompaniesHouse.Response.Document;
using CompaniesHouse.Response.RegisteredOfficeAddress;
using Shouldly;
using Xunit;

namespace CompaniesHouse.ScenarioTests
{
    public class RegisteredOfficeAndDocumentsScenarios
    {
        [Fact]
        public void RegisteredOfficeAddress_DeserializesForeignCountryWithoutEnumFailure()
        {
            const string json = """
                {
                  "etag":"185a52c646d2f03c05127df15915f784e41acf60",
                  "kind":"registered-office-address",
                  "links":{"self":"/company/FC040879/registered-office-address"},
                  "address_line_1":"Absa Towers West",
                  "address_line_2":"15 Troye Street",
                  "country":"South Africa",
                  "locality":"Johannesburg",
                  "region":"Gauteng 2000"
                }
                """;

            var value = JsonSerializer.Deserialize<OfficeAddress>(json, CompaniesHouseJsonSerializerOptions.Default);

            value.ShouldNotBeNull();
            value.Country.ShouldBe("South Africa");
            value.Region.ShouldBe("Gauteng 2000");
        }

        [Fact]
        public void DocumentMetadata_DeserializesObservedFields()
        {
            const string json = """
                {
                  "company_number":"00445790",
                  "barcode":"XF5EZFHE",
                  "significant_date":null,
                  "significant_date_type":"",
                  "category":"annual-returns",
                  "pages":3,
                  "filename":"00445790_cs01_2026-07-01",
                  "created_at":"2026-07-01T08:28:44.698561376Z",
                  "links":{"self":"https://document-api.company-information.service.gov.uk/document/IHFGB_pcm7rSIRefsfuXK1MDkLFxrSoHbKKAgY7OTxk","document":"https://document-api.company-information.service.gov.uk/document/IHFGB_pcm7rSIRefsfuXK1MDkLFxrSoHbKKAgY7OTxk/content"},
                  "resources":{"application/pdf":{"content_length":82803}}
                }
                """;

            var value = JsonSerializer.Deserialize<DocumentMetadata>(json, CompaniesHouseJsonSerializerOptions.Default);

            value.ShouldNotBeNull();
            value.CreatedAt.ShouldNotBeNull();
            value.CreatedAt.Value.Year.ShouldBe(2026);
            value.CreatedAt.Value.Month.ShouldBe(7);
            value.CreatedAt.Value.Day.ShouldBe(1);
            value.Resources.ShouldNotBeNull();
            value.Resources["application/pdf"].ContentLength.ShouldBe(82803);
        }
    }
}

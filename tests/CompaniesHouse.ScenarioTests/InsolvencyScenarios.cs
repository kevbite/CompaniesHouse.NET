using System;
using System.Text.Json;
using CompaniesHouse.Response.Insolvency;
using Shouldly;
using Xunit;

namespace CompaniesHouse.ScenarioTests
{
    public class InsolvencyScenarios
    {
        [Fact]
        public void CompanyInsolvencyInformation_DeserializesStatusesAndCaseDates()
        {
            const string json = """
                {
                  "cases":[
                    {
                      "type":"creditors-voluntary-liquidation",
                      "dates":[
                        {"type":"voluntary-arrangement-ceased-to-have-effect","date":"2013-05-29"},
                        {"type":"liquidation-started-on","date":"2013-05-29"}
                      ],
                      "practitioners":[
                        {"name":"Richard David Hill","address":{"address_line_1":"Grant Thornton Uk Llp","address_line_2":"4 Hardman Square","locality":"Spinningfields","region":"Manchester","postal_code":"M3 3EB"},"appointed_on":"2013-05-29","role":"liquidator"}
                      ],
                      "number":"1"
                    }
                  ],
                  "status":["liquidation"]
                }
                """;

            var value = JsonSerializer.Deserialize<CompanyInsolvencyInformation>(json, CompaniesHouseJsonSerializerOptions.Default);

            value.ShouldNotBeNull();
            value.Status.ShouldBe([new InsolvencyStatus("liquidation")]);
            value.Cases[0].Type.ShouldBe(InsolvencyCaseType.CreditorsVoluntaryLiquidation);
            value.Cases[0].Dates.ShouldContain(x => x.Type == new CaseDateType("liquidation-started-on") && x.Date == new DateTime(2013, 05, 29));
        }
    }
}

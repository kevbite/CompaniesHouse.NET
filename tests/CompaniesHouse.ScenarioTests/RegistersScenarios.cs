using System;
using System.Text.Json;
using CompaniesHouse.Response.Registers;
using Shouldly;
using Xunit;

namespace CompaniesHouse.ScenarioTests
{
    public class RegistersScenarios
    {
        [Fact]
        public void CompanyRegisters_DeserializesObservedSparseLivePayload()
        {
            var value = JsonSerializer.Deserialize<CompanyRegisters>(RegistersJson, CompaniesHouseJsonSerializerOptions.Default);

            value.ShouldNotBeNull();
            value.Kind.ShouldBe("registers");
            value.Links.Self.ShouldBe("/company/10725338/registers");
            value.CompanyNumber.ShouldBeNull();
            value.Registers.Directors.ShouldNotBeNull();
            value.Registers.Directors.Items.Length.ShouldBe(2);
            value.Registers.Directors.Items[0].MovedOn.ShouldBe(new DateTime(2025, 11, 18));
            value.Registers.Directors.Items[0].RegisterMovedTo.ShouldBe("unspecified-location");
            value.Registers.UsualResidentialAddress.ShouldNotBeNull();
            value.Registers.Secretaries.ShouldBeNull();
        }

        private const string RegistersJson = """
            {
              "links": {
                "self": "/company/10725338/registers"
              },
              "kind": "registers",
              "registers": {
                "directors": {
                  "register_type": "directors",
                  "items": [
                    {
                      "moved_on": "2025-11-18",
                      "register_moved_to": "unspecified-location"
                    },
                    {
                      "moved_on": "2017-04-13",
                      "register_moved_to": "public-register"
                    }
                  ]
                },
                "usual_residential_address": {
                  "register_type": "usual-residential-address",
                  "items": [
                    {
                      "moved_on": "2025-11-18",
                      "register_moved_to": "unspecified-location"
                    },
                    {
                      "moved_on": "2017-04-13",
                      "register_moved_to": "public-register"
                    }
                  ]
                }
              },
              "etag": "9b6222e6f8614ced4bf26e557e1e8fd811952487"
            }
            """;
    }
}

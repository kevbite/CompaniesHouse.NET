using System;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.UriBuilders;
using Moq;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.CompaniesHouseRegistersClientTests
{
    public class CompaniesHouseRegistersClientTests
    {
        [Fact]
        public async Task GivenARealCapturedRegistersPayload_WhenGettingCompanyRegisters_ThenObservedFieldsDeserialize()
        {
            var uri = new Uri("https://wibble.com/company/10725338/registers");
            HttpMessageHandler handler = new StubHttpMessageHandler(uri, RealRegistersJson);

            var uriBuilder = new Mock<ICompanyRegistersUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>())).Returns(uri);

            var client = new CompaniesHouseRegistersClient(new HttpClient(handler), uriBuilder.Object);
            var result = await client.GetCompanyRegistersAsync("10725338");

            result.Data.ShouldNotBeNull();
            result.Data.Kind.ShouldBe("registers");
            result.Data.Etag.ShouldBe("9b6222e6f8614ced4bf26e557e1e8fd811952487");
            result.Data.Links.Self.ShouldBe("/company/10725338/registers");
            result.Data.CompanyNumber.ShouldBeNull();
            result.Data.Registers.Directors.ShouldNotBeNull();
            result.Data.Registers.Directors.RegisterType.ShouldBe("directors");
            result.Data.Registers.Directors.Items.Length.ShouldBe(2);
            result.Data.Registers.Directors.Items[0].MovedOn.ShouldBe(new DateTime(2025, 11, 18));
            result.Data.Registers.Directors.Items[0].RegisterMovedTo.ShouldBe("unspecified-location");
            result.Data.Registers.Directors.Items[0].Links.ShouldBeNull();
            result.Data.Registers.UsualResidentialAddress.ShouldNotBeNull();
            result.Data.Registers.UsualResidentialAddress.RegisterType.ShouldBe("usual-residential-address");
            result.Data.Registers.Secretaries.ShouldBeNull();
            result.Data.Registers.Members.ShouldBeNull();
        }

        private const string RealRegistersJson = """
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

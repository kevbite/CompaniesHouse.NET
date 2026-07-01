using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Response.RegisteredOfficeAddress;
using CompaniesHouse.Tests.ResourceBuilders;
using CompaniesHouse.UriBuilders;
using Moq;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.CompaniesHouseRegisteredOfficeAddressTests
{
    public class CompaniesHouseRegisteredOfficeAddressTests
    {
        [Theory]
        [MemberData(nameof(TestCases))]
        public async Task GivenACompaniesHouseRegistereOfficeAddressClient_WhenGettingARegisteredOfficeAddress(CompaniesHouseRegisteredOfficeAddressTestCase testCase)
        {
            var registeredOfficeAddress = RegisteredOfficeAddressBuilder.Build(testCase);
            var resource = new RegisteredOfficeAddressResourceBuilder(registeredOfficeAddress).Create();

            var uri = new Uri("https://wibble.com/company/wobble/registered-office-address");

            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);

            var uriBuilder = new Mock<IRegisteredOfficeAddressUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>())).Returns(uri);

            var client = new CompaniesHouseRegisteredOfficeAddressClient(new HttpClient(handler), uriBuilder.Object);

            var result = await client.GetRegisteredOfficeAddress("abc");

            EquivalencyAssertionExtensions.ShouldBeEquivalentTo((object)result.Data, registeredOfficeAddress);
        }

        public static IEnumerable<object[]> TestCases() =>
            EnumerationMappings.PossibleRegisteredOfficeAddressCountry.Keys
                .Select(x => new CompaniesHouseRegisteredOfficeAddressTestCase
                {
                    Country = x
                })
                .Select(testCase => new object[] { testCase });

        [Fact]
        public async Task GivenARealCapturedPayload_WhenGettingARegisteredOfficeAddress_ThenAllObservedFieldsDeserialize()
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

            var uri = new Uri("https://wibble.com/company/FC040879/registered-office-address");
            HttpMessageHandler handler = new StubHttpMessageHandler(uri, json);

            var uriBuilder = new Mock<IRegisteredOfficeAddressUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>())).Returns(uri);

            var client = new CompaniesHouseRegisteredOfficeAddressClient(new HttpClient(handler), uriBuilder.Object);

            var result = await client.GetRegisteredOfficeAddress("FC040879");

            result.Data.ShouldNotBeNull();
            result.Data.Country.ShouldBe("South Africa");
            result.Data.Kind.ShouldBe("registered-office-address");
            result.Data.Region.ShouldBe("Gauteng 2000");
            result.Data.Links?.Self.ShouldBe("/company/FC040879/registered-office-address");
        }
    }
}
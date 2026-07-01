using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
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

            EquivalencyAssertionExtensions.ShouldBeEquivalentTo((object)result.Data, registeredOfficeAddress, nameof(RegisteredOfficeAddress.Country));

            result.Data.Country.GetEnumMemberValue().ShouldBe(registeredOfficeAddress.Country);
        }

        public static IEnumerable<object[]> TestCases() =>
            EnumerationMappings.PossibleRegisteredOfficeAddressCountry.Keys
                .Select(x => new CompaniesHouseRegisteredOfficeAddressTestCase
                {
                    Country = x
                })
                .Select(testCase => new object[] { testCase });
    }

    internal static class EnumExtensions
    {
        public static string GetEnumMemberValue(this Enum enumValue)
        {
            var type = enumValue.GetType();
            var info = type.GetField(enumValue.ToString());
            var enumMember = (EnumMemberAttribute[])info.GetCustomAttributes(typeof(EnumMemberAttribute), false);

            return enumMember.Length > 0 ? enumMember[0].Value : string.Empty;
        }
    }
}
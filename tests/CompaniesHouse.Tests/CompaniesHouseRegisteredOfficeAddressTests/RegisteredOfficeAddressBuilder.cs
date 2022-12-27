using AutoFixture;
using CompaniesHouse.Tests.ResourceBuilders;

namespace CompaniesHouse.Tests.CompaniesHouseRegisteredOfficeAddressTests
{
    public static class RegisteredOfficeAddressBuilder
    {
        public static OfficeAddress Build(CompaniesHouseRegisteredOfficeAddressTestCase testCase) =>
            new Fixture()
                .Build<OfficeAddress>()
                .With(x => x.Country, testCase.Country)
                .Create();
    }
}
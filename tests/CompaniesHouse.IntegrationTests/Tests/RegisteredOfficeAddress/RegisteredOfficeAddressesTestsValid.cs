using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.RegisteredOfficeAddress
{

    public class RegisteredOfficeAddressesTestsValid : RegisteredOfficeAddressTestBase
    {
        private const string CompanyNumber = "03977902";

        protected override async Task When() => Result = await Client.GetRegisteredOfficeAddress(CompanyNumber);

        [Fact]
        public void ThenRegisteredOfficeAddressIsNotNull() => Result.Data.ShouldNotBeNull();

        [Fact]
        public void ThenObservedFieldsAreReturned()
        {
            Result.Data.Country.ShouldBe("United Kingdom");
            Result.Data.Links?.Self.ShouldBe("/company/03977902/registered-office-address");
        }
    }
}
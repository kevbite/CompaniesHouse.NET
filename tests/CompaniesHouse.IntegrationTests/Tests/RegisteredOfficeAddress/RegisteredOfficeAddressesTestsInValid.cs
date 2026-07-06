using System.Threading.Tasks;
using CompaniesHouse.Response.RegisteredOfficeAddress;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.RegisteredOfficeAddress
{
    
    public class RegisteredOfficeAddressesTestsInValid : RegisteredOfficeAddressTestBase
    {
        private const string InvalidCompanyNumber = "ABC00000";

        protected override async Task When() => Result = await Client.GetRegisteredOfficeAddress(InvalidCompanyNumber);
        
        [IntegrationFact]
        public void ThenRegisteredOfficeAddressIsNull() => Result.ShouldBeOfType<CompaniesHouseResponse<OfficeAddress>.NotFound>();
    }
}

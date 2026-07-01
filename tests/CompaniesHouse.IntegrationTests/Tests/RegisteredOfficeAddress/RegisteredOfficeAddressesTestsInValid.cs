using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.RegisteredOfficeAddress
{
    
    public class RegisteredOfficeAddressesTestsInValid : RegisteredOfficeAddressTestBase
    {
        private const string InvalidCompanyNumber = "ABC00000";

        protected override async Task When() => Result = await Client.GetRegisteredOfficeAddress(InvalidCompanyNumber);
        
        [Fact]
        public void ThenRegisteredOfficeAddressIsNull() => Result.Data.ShouldBeNull();
    }
}

using System.Threading.Tasks;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.RegisteredOfficeAddress
{
    [TestFixture]
    public class RegisteredOfficeAddressesTestsInvalid : RegisteredOfficeAddressTestBase
    {
        private const string CompanyNumber = "00000000";

        protected override async Task When() => Result = await Client.GetRegisteredOfficeAddress(CompanyNumber);
        
        [Test]
        public void ThenRegisteredOfficeAddressIsNull() => Assert.Null(Result.Data);
    }
}
using System.Threading.Tasks;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.RegisteredOfficeAddress
{
    [TestFixture]
    public class RegisteredOfficeAddressesTestsValid : RegisteredOfficeAddressTestBase
    {
        private const string CompanyNumber = "03977902";

        protected override async Task When() => Result = await Client.GetRegisteredOfficeAddress(CompanyNumber);
        
        [Test]
        public void ThenRegisteredOfficeAddressIsNotNull() => Assert.NotNull(Result.Data);
    }
}
using System.Threading.Tasks;
using CompaniesHouse.Response.RegisteredOfficeAddress;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.RegisteredOfficeAddress
{
    public abstract class RegisteredOfficeAddressTestBase
    {
        protected CompaniesHouseClient Client { get; set; }
        protected CompaniesHouseClientResponse<OfficeAddress> Result; 

        [SetUp]
        public async Task Setup()
        {
            GivenACompaniesHouseClient();
            await When().ConfigureAwait(false);
        }
        protected abstract Task When();

        private void GivenACompaniesHouseClient()
        {
            Client = new CompaniesHouseClient(new CompaniesHouseSettings(CompaniesHouseUris.Default, Keys.ApiKey));
        }
    }
}
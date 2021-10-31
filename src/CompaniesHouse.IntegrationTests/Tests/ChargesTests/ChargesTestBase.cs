using System.Threading.Tasks;
using CompaniesHouse.Response.Charges;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.ChargesTests
{
    public abstract class ChargesTestBase<T>
    {
        protected CompaniesHouseClient Client { get; set; }
        protected CompaniesHouseClientResponse<T> Result; 

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
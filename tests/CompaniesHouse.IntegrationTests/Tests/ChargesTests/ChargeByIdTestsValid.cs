using System.Threading.Tasks;
using CompaniesHouse.Response.Charges;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.ChargesTests
{
    
    public class ChargeByIdTestsValid : ChargesTestBase<Charge>
    {
        private const string CompanyNumber = "00445790";
        private const string ChargeId = "5QU1lSudRI2jTIfUv_AOVxfLxVE";

        protected override async Task When() => Result = await Client.GetChargeByIdAsync(CompanyNumber, ChargeId);

        [Fact]
        public void ThenChargesListIsNull() => Result.Data.ShouldNotBeNull();
    }
}
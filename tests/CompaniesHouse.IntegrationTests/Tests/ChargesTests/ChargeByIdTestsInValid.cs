using System.Threading.Tasks;
using CompaniesHouse.Response.Charges;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.ChargesTests
{
    
    public class ChargeByIdTestsInValid : ChargesTestBase<Charge>
    {
        private const string CompanyNumber = "00000000";
        private const string ChargeId = "00000000";

        protected override async Task When() => Result = await Client.GetChargeByIdAsync(CompanyNumber, ChargeId);

        [Fact]
        public void ThenChargesListIsNull() => Result.Data.ShouldBeNull();
    }
}
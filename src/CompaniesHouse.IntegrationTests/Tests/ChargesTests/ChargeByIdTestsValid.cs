using System.Threading.Tasks;
using CompaniesHouse.Response.Charges;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.ChargesTests
{
    [TestFixture]
    public class ChargeByIdTestsValid : ChargesTestBase<Charge>
    {
        private const string CompanyNumber = "00445790";
        private const string ChargeId = "5QU1lSudRI2jTIfUv_AOVxfLxVE";

        protected override async Task When() => Result = await Client.GetChargeByIdAsync(CompanyNumber, ChargeId);

        [Test]
        public void ThenChargesListIsNull() => Assert.IsNotNull(Result.Data);
    }
}
using System.Threading.Tasks;
using CompaniesHouse.Response.Charges;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.ChargesTests
{
    [TestFixture]
    public class ChargeByIdTestsInValid : ChargesTestBase<Charge>
    {
        private const string CompanyNumber = "00000000";
        private const string ChargeId = "00000000";

        protected override async Task When() => Result = await Client.GetChargeByIdAsync(CompanyNumber, ChargeId);

        [Test]
        public void ThenChargesListIsNull() => Assert.Null(Result.Data);
    }
}
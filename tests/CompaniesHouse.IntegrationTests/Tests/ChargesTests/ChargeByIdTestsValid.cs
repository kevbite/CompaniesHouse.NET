using System.Threading.Tasks;
using CompaniesHouse.Response.Charges;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.ChargesTests
{

    public class ChargeByIdTestsValid : ChargesTestBase<Charge>
    {
        private const string CompanyNumber = "03977902";
        private const string ChargeId = "4VMbVfCBWdzCW2fXOF5QTezbJ9g";

        protected override async Task When() => Result = await Client.GetChargeByIdAsync(CompanyNumber, ChargeId);

        [Fact]
        public void ThenChargesListIsNull() => Result.Data.ShouldNotBeNull();

        [Fact]
        public void ThenKnownObservedFieldsAreReturned()
        {
            Result.Data.Status.Value.ShouldNotBeNullOrWhiteSpace();
            Result.Data.Classification?.Type.Value.ShouldNotBeNullOrWhiteSpace();
            Result.Data.Links?.Self.ShouldBe($"/company/{CompanyNumber}/charges/{ChargeId}");
        }
    }
}
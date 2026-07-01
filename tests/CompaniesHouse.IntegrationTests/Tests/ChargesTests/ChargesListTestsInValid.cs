using System.Threading.Tasks;
using CompaniesHouse.Response.Charges;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.ChargesTests
{
    
    public class ChargesListTestsInValid : ChargesTestBase<Charges>
    {
        private const string CompanyNumber = "00000000";

        protected override async Task When() => Result = await Client.GetChargesListAsync(CompanyNumber);

        [IntegrationFact]
        public void ThenChargesListIsNull() => Result.Data.Items.ShouldBeEmpty();
    }
}
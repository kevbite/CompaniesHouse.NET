using System.Threading.Tasks;
using CompaniesHouse.Response.Charges;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.ChargesTests
{
    [TestFixture]
    public class ChargesListTestsInValid : ChargesTestBase<Charges>
    {
        private const string CompanyNumber = "00000000";

        protected override async Task When() => Result = await Client.GetChargesListAsync(CompanyNumber);

        [Test]
        public void ThenChargesListIsNull() => Assert.IsEmpty(Result.Data.Items);
    }
}
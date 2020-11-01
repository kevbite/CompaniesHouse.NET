using System.Threading.Tasks;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.ChargesTests
{
    [TestFixture]
    public class ChargesListTestsInValid : ChargesTestBase
    {
        private const string CompanyNumber = "00000000";

        protected override async Task When() => Result = await Client.GetChargesListAsync(CompanyNumber);

        [Test]
        public void ThenChargesListIsNull() => Assert.Null(Result.Data);
    }
}
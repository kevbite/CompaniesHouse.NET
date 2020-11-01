using System.Threading.Tasks;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.ChargesTests
{
    [TestFixture]
    public class ChargesListTestsValid : ChargesTestBase
    {
        private const string CompanyNumber = "00445790";
        protected override async Task When() => Result = await Client.GetChargesListAsync(CompanyNumber);


        [Test]
        public void ThenChargesListIsNotEmpty()
        {
            Assert.NotNull(Result.Data);
            Assert.IsNotEmpty(Result.Data.Items);
        }
    }
}

using System.Threading.Tasks;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.ChargesTests
{
    [TestFixtureSource(nameof(TestCases))]
    public class ChargesListTestsValid : ChargesTestBase
    {
        private readonly string _companyNumber;

        public ChargesListTestsValid(string companyNumber) => _companyNumber = companyNumber;
        protected override async Task When() => Result = await Client.GetChargesListAsync(_companyNumber);

        [Test]
        public void ThenChargesListIsNotEmpty() => Assert.IsNotEmpty(Result.Data.Items);

        public static string[] TestCases()
        {
            return new[]
            {
                "03977902", // Google
                "00445790", // Tesco
                "00002065", // Lloyds Bank PLCo
                "03487070"
            };
        } 
    }
}

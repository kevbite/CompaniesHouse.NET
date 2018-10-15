using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompaniesHouse.Response.CompanyFiling;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyFilingHistoryTests
{
    [TestFixtureSource(nameof(TestCases))]
    public class CompanyFilingHistoryTestsValid : CompanyFilingHistoryTestBase
    {
        private readonly string _companyNumber;
        private List<FilingHistoryItem> _results;

        public CompanyFilingHistoryTestsValid(string companyNumber)
        {
            _companyNumber = companyNumber;
        }

        public static string[] TestCases()
        {
            return new[]
            {
                "03977902", // Google
                "00445790", // Tesco
                "00002065", // Lloyds Bank PLC
                "09965459",  // Amazebytes
                "06768813",  // TEST & COOL LTD,
                "00059337",
                "06484911"
            };
        }

        protected override async Task When()
        {
            var page = 0;
            var size = 100;
            _results = new List<FilingHistoryItem>();

            CompaniesHouseClientResponse<CompanyFilingHistory> result;
            do
            {
                result = await _client.GetCompanyFilingHistoryAsync(_companyNumber, page++ * size, size);
                _results.AddRange(result.Data.Items);
            } while (result.Data.Items.Any());
        }

        [Test]
        public void ThenTheDataItemsAreNotEmpty()
        {
            Assert.That(_results, Is.Not.Empty);
        }
    }
}

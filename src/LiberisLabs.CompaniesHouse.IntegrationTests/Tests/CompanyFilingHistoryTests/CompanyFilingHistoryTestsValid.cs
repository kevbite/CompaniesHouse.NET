using System.Collections.Generic;
using System.Linq;
using LiberisLabs.CompaniesHouse.Response.CompanyFiling;
using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.IntegrationTests.Tests.CompanyFilingHistoryTests
{
    [TestFixture]
    public class CompanyFilingHistoryTestsValid : CompanyFilingHistoryTestBase
    {
        public static string[] TestCases()
        {
            return new[]
            {
                "03977902", // Google
                "00445790", // Tesco
                "00002065", // Lloyds Bank PLC
                "09965459"  // Amazebytes
            };
        }

        protected override void When()
        {
        }

        [TestCaseSource(nameof(TestCases))]
        public void ThenTheDataItemsAreNotEmpty(string testCase)
        {
            var page = 0;
            var size = 100;
            var results = new List<FilingHistoryItem>();

            do
            {
                _result = _client.GetCompanyFilingHistoryAsync(testCase, page++ * size, size).Result;
                results.AddRange(_result.Data.Items);
            } while (_result.Data.Items.Any());

            Assert.That(results, Is.Not.Empty);
        }
    }
}

using System.Threading.Tasks;
using CompaniesHouse.Response;
using CompaniesHouse.Response.CompanyFiling;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyFilingHistoryTests
{
    [TestFixture]
    public class CompanyFilingHistoryTestsInvalid : CompanyFilingHistoryTestBase
    {
        private const string InvalidCompanyNumber = "ABC00000";

        private CompaniesHouseClientResponse<CompanyFilingHistory> _result;

        protected override async Task When()
        {
            await WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
                .ConfigureAwait(false);
        }

        [Test]
        public void ThenTheDataHasSomeEmptyPropertiesAndStatusOfInvalidFormat()
        {
            Assert.That(_result.Data.Items, Is.Empty);
            Assert.That(_result.Data.HistoryStatus, Is.EqualTo(FilingHistoryStatus.InvalidFormat));
            Assert.That(_result.Data.StartIndex, Is.EqualTo(0));
            Assert.That(_result.Data.TotalCount, Is.EqualTo(0));

        }

        private async Task WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
        {
            _result = await _client.GetCompanyFilingHistoryAsync(InvalidCompanyNumber)
                .ConfigureAwait(false);
        }
    }
}

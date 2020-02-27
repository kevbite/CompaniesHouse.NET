using System.Threading.Tasks;
using NUnit.Framework;

namespace CompaniesHouse.Core.IntegrationTests.Tests.CompanyProfileTests
{
    [TestFixture]
    public class CompanyProfileTestsValid : CompanyProfileTestsBase
    {
        // Google UK company number, unlikely to go away soon
        private const string ValidCompanyNumber = "03977902";

        [SetUp]
        protected override async Task When()
        {
            await WhenRetrievingAValidCompanyProfile()
                .ConfigureAwait(false);
        }

        [Test]
        public void ThenTheProfileIsReturned()
        {
            Assert.That(_result.Data.CompanyName, Is.Not.Empty);
        }

        private async Task WhenRetrievingAValidCompanyProfile()
        {
            _result = await _client.GetCompanyProfileAsync(ValidCompanyNumber)
                .ConfigureAwait(false);
        }
    }
}

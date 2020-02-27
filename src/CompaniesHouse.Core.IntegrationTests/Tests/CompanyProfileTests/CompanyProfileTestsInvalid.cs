using System.Threading.Tasks;
using NUnit.Framework;

namespace CompaniesHouse.Core.IntegrationTests.Tests.CompanyProfileTests
{
    [TestFixture]
    public class CompanyProfileTestsInvalid : CompanyProfileTestsBase
    {
        private const string InvalidCompanyNumber = "ABC00000";

        [SetUp]
        protected override async Task When()
        {
            await WhenRetrievingAnInvalidCompanyProfile()
                .ConfigureAwait(false);
        }

        [Test]
        public void ThenTheProfileIsNotReturned()
        {
            Assert.That(_result.Data, Is.Null);
        }

        private async Task WhenRetrievingAnInvalidCompanyProfile()
        {
            _result = await _client.GetCompanyProfileAsync(InvalidCompanyNumber)
                .ConfigureAwait(false);
        }
    }
}

using System.Threading.Tasks;
using NUnit.Framework;


namespace CompaniesHouse.Core.IntegrationTests.Tests.PersonsWithSignificantControlTests
{
    [TestFixture]
    public class PersonsWithSignificantControlTestsInValid : PersonsWithSignificantControlTestBase
    {
        private const string InvalidCompanyNumber = "ABC00000";

        [SetUp]
        protected override async Task When()
        {
            await WhenRetrievingAnCompanyPersonsWithSignificantControlForAnInvalidCompany().ConfigureAwait(false);
        }


        [Test]
        public void ThenTheDataItemsAreNull()
        {
            Assert.That(_result.Data, Is.Null);
        }

        private async Task WhenRetrievingAnCompanyPersonsWithSignificantControlForAnInvalidCompany()
        {
            _result = await _client.GetPersonsWithSignificantControlAsync(InvalidCompanyNumber).ConfigureAwait(false);
        }
    }
}

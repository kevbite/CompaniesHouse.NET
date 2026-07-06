using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.PersonsWithSignificantControlTests
{

    public class PersonsWithSignificantControlTestsInValid : PersonsWithSignificantControlTestBase
    {
        private const string InvalidCompanyNumber = "ABC00000";


        protected override async Task When()
        {
            await WhenRetrievingAnCompanyPersonsWithSignificantControlForAnInvalidCompany();
        }

        [IntegrationFact]
        public void ThenTheDataItemsAreNull()
        {
            _result.Data.ShouldNotBeNull();
            _result.Data.Items.ShouldBeEmpty();
        }

        private async Task WhenRetrievingAnCompanyPersonsWithSignificantControlForAnInvalidCompany()
        {
            _result = await _client.GetPersonsWithSignificantControlAsync(InvalidCompanyNumber);
        }
    }
}

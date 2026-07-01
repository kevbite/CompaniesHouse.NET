using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.PersonsWithSignificantControlTests
{
    
    public class PersonsWithSignificantControlTestsValid : PersonsWithSignificantControlTestBase
    {
        // Google UK company number, unlikely to go away soon
        private const string ValidCompanyNumber = "03977902";

        
        protected override async Task When()
        {
            await WhenRetrievingAnCompanyPersonsWithSignificantControlForAnValidCompany();
        }

        [Fact]
        public void ThenTheDataItemsAreNotEmpty()
        {
            _result.Data.Items.ShouldNotBeEmpty();
        }

        private async Task WhenRetrievingAnCompanyPersonsWithSignificantControlForAnValidCompany()
        {
            _result = await _client.GetPersonsWithSignificantControlAsync(ValidCompanyNumber);
        }
    }
}

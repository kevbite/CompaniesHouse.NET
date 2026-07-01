using System.Threading.Tasks;
using CompaniesHouse.Response.Officers;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.OfficerTests
{
    
    public class OfficersTestsValid : OfficersTestBase<Officers>
    {
        // Google UK company number, unlikely to go away soon
        private const string ValidCompanyNumber = "03977902";

        
        protected override async Task When()
        {
            await WhenRetrievingAnCompanyFilingHistoryForAValidCompany()
                ;
        }

        [Fact]
        public void ThenTheDataItemsAreNotEmpty()
        {
            Result.Data.Items.ShouldNotBeEmpty();
        }

        private async Task WhenRetrievingAnCompanyFilingHistoryForAValidCompany()
        {
            Result = await Client.GetOfficersAsync(ValidCompanyNumber)
                ;
        }
    }
}

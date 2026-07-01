using System.Threading.Tasks;
using CompaniesHouse.Response.Officers;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.OfficerTests
{
    
    public class OfficersTestsInvalid : OfficersTestBase<Officers>
    {
        private const string InvalidCompanyNumber = "ABC00000";

        
        protected override async Task When()
        {
            await WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany();
        }

        [Fact]
        public void ThenTheDataItemsAreNull()
        {
            Result.Data.ShouldBeNull();
        }

        private async Task WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
        {
            Result = await Client.GetOfficersAsync(InvalidCompanyNumber);
        }
    }
}

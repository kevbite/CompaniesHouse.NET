using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.AppointmentsTests
{
    
    public class AppointmentsTestsValid : AppointmentsTestBase
    {
        // Sergey Brin's officer id
        private const string ValidOfficerId = "uQNQ-blSo-8PiOaehWClTPmbZNI";

        
        protected override async Task When()
        {
            await WhenRetrievingAppointmentsForAValidOfficer()
                ;
        }

        [Fact]
        public void ThenTheDataItemsAreNotEmpty()
        {
            Result.Data.Items.ShouldNotBeEmpty();
        }

        private async Task WhenRetrievingAppointmentsForAValidOfficer()
        {
            Result = await Client.GetAppointmentsAsync(ValidOfficerId);
        }
    }
}

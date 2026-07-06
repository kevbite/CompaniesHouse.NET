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

        [IntegrationFact]
        public void ThenTheDataItemsAreNotEmpty()
        {
            Result.Data.Items.ShouldNotBeEmpty();
        }

        [IntegrationFact]
        public void ThenObservedEnvelopeFieldsAreReturned()
        {
            Result.Data.Kind.ShouldBe("personal-appointment");
            Result.Data.Links?.Self.ShouldBe($"/officers/{ValidOfficerId}/appointments");
        }

        private async Task WhenRetrievingAppointmentsForAValidOfficer()
        {
            Result = await Client.GetAppointmentsAsync(ValidOfficerId);
        }
    }
}

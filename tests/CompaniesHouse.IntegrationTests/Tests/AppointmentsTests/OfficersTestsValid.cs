using System.Threading.Tasks;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.AppointmentsTests
{
    [TestFixture]
    public class AppointmentsTestsValid : AppointmentsTestBase
    {
        // Sergey Brin's officer id
        private const string ValidOfficerId = "uQNQ-blSo-8PiOaehWClTPmbZNI";

        [SetUp]
        protected override async Task When()
        {
            await WhenRetrievingAppointmentsForAValidOfficer()
                .ConfigureAwait(false);
        }

        [Test]
        public void ThenTheDataItemsAreNotEmpty()
        {
            Assert.That(Result.Data.Items, Is.Not.Empty);
        }

        private async Task WhenRetrievingAppointmentsForAValidOfficer()
        {
            Result = await Client.GetAppointmentsAsync(ValidOfficerId).ConfigureAwait(false);
        }
    }
}

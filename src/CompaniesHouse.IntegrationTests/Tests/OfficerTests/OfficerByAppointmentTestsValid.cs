using System.Threading.Tasks;
using CompaniesHouse.Response.Officers;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.OfficerTests
{
    [TestFixture]
    public class OfficerByAppointmentTestsValid : OfficersTestBase<Officer>
    {
        // Google UK company number, unlikely to go away soon
        private const string ValidCompanyNumber = "03977902";
        
        //Sergey Brin's appointment
        private const string AppointmentId = "UmNUS-JYLQPmuNSz-DgKNbA2v7c";
        
        [SetUp]
        protected override async Task When() => 
            await WhenRetrievingAnCompanyFilingHistoryForAValidCompany()
                .ConfigureAwait(false);

        private async Task WhenRetrievingAnCompanyFilingHistoryForAValidCompany() => 
            Result = await Client
                .GetOfficerByAppointmentIdAsync(ValidCompanyNumber, AppointmentId)
                .ConfigureAwait(false);
        
        
        [Test]
        public void ThenTheDataIsNotNull() => 
            Assert.That(Result.Data, Is.Not.Null);
    }
}
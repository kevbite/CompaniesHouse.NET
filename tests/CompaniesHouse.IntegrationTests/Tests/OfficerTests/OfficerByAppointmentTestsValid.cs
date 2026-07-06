using System.Threading.Tasks;
using CompaniesHouse.Response.Officers;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.OfficerTests
{
    
    public class OfficerByAppointmentTestsValid : OfficersTestBase<Officer>
    {
        // Google UK company number, unlikely to go away soon
        private const string ValidCompanyNumber = "03977902";
        
        //Sergey Brin's appointment
        private const string AppointmentId = "UmNUS-JYLQPmuNSz-DgKNbA2v7c";
        
        
        protected override async Task When() => 
            await WhenRetrievingAnCompanyFilingHistoryForAValidCompany()
                ;

        private async Task WhenRetrievingAnCompanyFilingHistoryForAValidCompany() => 
            Result = await Client
                .GetOfficerByAppointmentIdAsync(ValidCompanyNumber, AppointmentId)
                ;
        
        
        [IntegrationFact]
        public void ThenTheDataIsNotNull() => 
            Result.Data.ShouldNotBeNull();
    }
}
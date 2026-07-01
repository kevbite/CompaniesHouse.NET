using System.Threading.Tasks;
using CompaniesHouse.Response.Officers;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.OfficerTests
{
    
    public class OfficerByAppointmentTestsInvalid : OfficersTestBase<Officer>
    {
        private const string InvalidCompanyNumber = "ABC00000";
        private const string InvalidAppointmentId = "000000000000000000000000000";

        protected override async Task When() =>
            Result = await Client.GetOfficerByAppointmentIdAsync(InvalidCompanyNumber, InvalidAppointmentId);

        [Fact]
        public void ThenTheDataIsNull() => Result.Data.ShouldBeNull();
    }
}

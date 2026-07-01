using System;
using System.Threading.Tasks;
using CompaniesHouse.Response.Officers;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.OfficerTests
{
    public class OfficerByAppointmentSchemaTests
    {
        [Fact]
        public async Task GetOfficerByAppointmentIdAsync_DeserializesTheSharedOfficerShape()
        {
            var client = new CompaniesHouseClient(new CompaniesHouseSettings(Keys.ApiKey));

            var result = await client.GetOfficerByAppointmentIdAsync("00445790", "gE7Pw_lx4HWJvqSfwqudfusS9Ig");

            result.Data.ShouldNotBeNull();
            result.Data.OfficerRole.ShouldBe(OfficerRole.Director);
            result.Data.PersonNumber.ShouldBe("248450070003");
            result.Data.IsPre1992Appointment.ShouldBe(false);
            result.Data.OfficerId.ShouldBe("aqrS_F-2zIvSaMNtl1opqDV4-w0");
            result.Data.IdentityVerificationDetails.ShouldNotBeNull();
            result.Data.IdentityVerificationDetails.AppointmentVerificationEndOn.ShouldBe(new DateTime(9999, 12, 31));
            result.Data.IdentityVerificationDetails.PreferredName.ShouldBe("Melissa Bethell");
        }
    }
}

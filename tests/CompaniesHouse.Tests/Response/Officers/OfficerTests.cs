using System.Text.Json;
using CompaniesHouse.Response.Officers;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.OfficerResponses
{
    public class OfficerTests
    {
        [Fact]
        public void OfficerId_ExtractsTheOfficerIdFromARealisticAppointmentsLink()
        {
            var officer = new Officer
            {
                Links = new OfficerLinks
                {
                    Officer = new OfficerAppointmentLink
                    {
                        AppointmentsResource = "/officers/uJ_F_UGCbPiYELlJ_fHc-J_goqo/appointments",
                    },
                },
            };

            officer.OfficerId.ShouldBe("uJ_F_UGCbPiYELlJ_fHc-J_goqo");
        }

        [Fact]
        public void OfficerId_IsIgnoredDuringSerialization()
        {
            var officer = new Officer
            {
                Links = new OfficerLinks
                {
                    Officer = new OfficerAppointmentLink
                    {
                        AppointmentsResource = "/officers/uJ_F_UGCbPiYELlJ_fHc-J_goqo/appointments",
                    },
                },
            };

            var json = JsonSerializer.Serialize(officer, CompaniesHouseJsonSerializerOptions.Default);

            json.ShouldNotContain("officer_id");
        }
    }
}

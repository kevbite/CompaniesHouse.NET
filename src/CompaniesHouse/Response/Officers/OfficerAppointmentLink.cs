using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Officers
{
    public class OfficerAppointmentLink
    {
        [JsonPropertyName("appointments")]
        public string AppointmentsResource { get; set; }

        public string OfficerId => AppointmentsResource?.Split('/')[2];
    }
}

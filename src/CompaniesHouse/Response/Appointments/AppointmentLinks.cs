using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Appointments
{
    public class AppointmentLinks
    {
        [JsonPropertyName("company")]
        public string? Company { get; set; }
    }
}

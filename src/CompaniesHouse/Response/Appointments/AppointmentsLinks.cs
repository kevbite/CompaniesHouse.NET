using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Appointments
{
    public class AppointmentsLinks
    {
        [JsonPropertyName("self")]
        public string? Self { get; set; }
    }
}

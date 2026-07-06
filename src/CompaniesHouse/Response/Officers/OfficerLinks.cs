using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Officers
{
    public class OfficerLinks
    {
        [JsonPropertyName("self")]
        public string? Self { get; set; }

        [JsonPropertyName("officer")]
        public OfficerAppointmentLink? Officer { get; set; }
    }
}

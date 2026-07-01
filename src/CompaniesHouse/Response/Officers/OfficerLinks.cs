using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Officers
{
    public class OfficerLinks
    {
        [JsonPropertyName("officer")]
        public OfficerAppointmentLink Officer { get; set; }
    }
}

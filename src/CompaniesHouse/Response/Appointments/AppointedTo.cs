using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Appointments
{
    public class AppointedTo
    {
        [JsonPropertyName("company_status")]
        public CompanyStatus CompanyStatus { get; set; }

        [JsonPropertyName("company_number")]
        public string? CompanyNumber { get; set; }

        [JsonPropertyName("company_name")]
        public string? CompanyName { get; set; }

    }
}

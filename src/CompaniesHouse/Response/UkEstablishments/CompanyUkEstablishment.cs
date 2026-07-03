using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.UkEstablishments
{
    public class CompanyUkEstablishment
    {
        [JsonPropertyName("company_number")]
        public string CompanyNumber { get; set; } = string.Empty;

        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; } = string.Empty;

        [JsonPropertyName("company_status")]
        public CompanyStatus CompanyStatus { get; set; }

        [JsonPropertyName("locality")]
        public string? Locality { get; set; }

        [JsonPropertyName("links")]
        public CompanyUkEstablishmentLinks Links { get; set; } = new();
    }
}

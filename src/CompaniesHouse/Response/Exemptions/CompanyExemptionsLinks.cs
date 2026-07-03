using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Exemptions
{
    public class CompanyExemptionsLinks
    {
        [JsonPropertyName("self")]
        public string Self { get; set; } = string.Empty;
    }
}

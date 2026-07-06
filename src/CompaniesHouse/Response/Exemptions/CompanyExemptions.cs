using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Exemptions
{
    public class CompanyExemptions
    {
        [JsonPropertyName("links")]
        public CompanyExemptionsLinks Links { get; set; } = new();

        [JsonPropertyName("kind")]
        public string Kind { get; set; } = string.Empty;

        [JsonPropertyName("etag")]
        public string Etag { get; set; } = string.Empty;

        [JsonPropertyName("exemptions")]
        public CompanyExemptionsDetail Exemptions { get; set; } = new();
    }
}

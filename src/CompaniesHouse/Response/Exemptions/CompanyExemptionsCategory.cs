using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Exemptions
{
    public class CompanyExemptionsCategory
    {
        [JsonPropertyName("items")]
        public CompanyExemptionPeriod[] Items { get; set; } = [];

        [JsonPropertyName("exemption_type")]
        public string ExemptionType { get; set; } = string.Empty;
    }
}

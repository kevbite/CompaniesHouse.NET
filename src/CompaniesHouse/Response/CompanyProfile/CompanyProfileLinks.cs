using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class CompanyProfileLinks
    {
        [JsonPropertyName("charges")]
        public required string Charges { get; set; }

        [JsonPropertyName("exemptions")]
        public string? Exemptions { get; set; }

        [JsonPropertyName("filing_history")]
        public required string FilingHistory { get; set; }

        [JsonPropertyName("insolvency")]
        public required string Insolvency { get; set; }

        [JsonPropertyName("officers")]
        public required string Officers { get; set; }

        [JsonPropertyName("persons_with_significant_control")]
        public required string PersonsWithSignificantControl { get; set; }

        [JsonPropertyName("persons_with_significant_control_statements")]
        public required string PersonsWithSignificantControlStatements { get; set; }

        [JsonPropertyName("registers")]
        public required string Registers { get; set; }

        [JsonPropertyName("self")]
        public required string Self { get; set; }

        [JsonPropertyName("uk_establishments")]
        public string? UkEstablishments { get; set; }
    }
}

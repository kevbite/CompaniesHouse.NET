using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class CompanyProfileLinks
    {
        [JsonPropertyName("charges")]
        public string Charges { get; set; }

        [JsonPropertyName("filing_history")]
        public string FilingHistory { get; set; }
        
        [JsonPropertyName("insolvency")]
        public string Insolvency { get; set; }
        
        [JsonPropertyName("officers")]
        public string Officers { get; set; }
        
        [JsonPropertyName("persons_with_significant_control")]
        public string PersonsWithSignificantControl { get; set; }
        
        [JsonPropertyName("persons_with_significant_control_statements")]
        public string PersonsWithSignificantControlStatements { get; set; }
        
        [JsonPropertyName("registers")]
        public string Registers { get; set; }
        
        [JsonPropertyName("self")]
        public string Self { get; set; }
    }
}

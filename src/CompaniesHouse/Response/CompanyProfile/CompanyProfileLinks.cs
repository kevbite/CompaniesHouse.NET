using Newtonsoft.Json;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class CompanyProfileLinks
    {
        [JsonProperty(PropertyName = "charges")]
        public string Charges { get; set; }

        [JsonProperty(PropertyName = "filing_history")]
        public string FilingHistory { get; set; }
        
        [JsonProperty(PropertyName = "insolvency")]
        public string Insolvency { get; set; }
        
        [JsonProperty(PropertyName = "officers")]
        public string Officers { get; set; }
        
        [JsonProperty(PropertyName = "persons_with_significant_control")]
        public string PersonsWithSignificantControl { get; set; }
        
        [JsonProperty(PropertyName = "persons_with_significant_control_statements")]
        public string PersonsWithSignificantControlStatements { get; set; }
        
        [JsonProperty(PropertyName = "registers")]
        public string Registers { get; set; }
        
        [JsonProperty(PropertyName = "self")]
        public string Self { get; set; }
    }
}
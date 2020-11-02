using Newtonsoft.Json;

namespace CompaniesHouse.Response.Charges
{
    public class InsolvencyCase
    {
        [JsonProperty("case_number")]
        public string CaseNumber { get; set; }
        
        [JsonProperty("links")]
        public InsolvencyCaseLinks Links { get; set; }
        
        [JsonProperty("transaction_id")]
        public int? TransactionId { get; set; }
    }
}
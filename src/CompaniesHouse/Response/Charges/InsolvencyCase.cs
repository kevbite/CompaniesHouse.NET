using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Charges
{
    public class InsolvencyCase
    {
        [JsonPropertyName("case_number")]
        public string CaseNumber { get; set; }
        
        [JsonPropertyName("links")]
        public InsolvencyCaseLinks Links { get; set; }
        
        [JsonPropertyName("transaction_id")]
        public long? TransactionId { get; set; }
    }
}

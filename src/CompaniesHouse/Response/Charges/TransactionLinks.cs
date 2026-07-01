using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Charges
{
    public class TransactionLinks
    {
        [JsonPropertyName("filing")]
        public string Filing { get; set; }
        
        [JsonPropertyName("insolvency_case")]
        public string InsolvencyCase { get; set; }
    }
}

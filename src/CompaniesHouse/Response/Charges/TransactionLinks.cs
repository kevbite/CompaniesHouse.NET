using Newtonsoft.Json;

namespace CompaniesHouse.Response.Charges
{
    public class TransactionLinks
    {
        [JsonProperty("filing")]
        public string Filing { get; set; }
        
        [JsonProperty("insolvency_case")]
        public string InsolvencyCase { get; set; }
    }
}
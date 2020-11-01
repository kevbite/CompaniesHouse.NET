using Newtonsoft.Json;

namespace CompaniesHouse.Response.Charges
{
    public class InsolvencyCaseLinks
    {
        [JsonProperty("case")]
        public string Case { get; set; }
    }
}
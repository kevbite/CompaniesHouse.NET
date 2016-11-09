using Newtonsoft.Json;

namespace CompaniesHouse.Response.Insolvency
{
    public class Links
    {
        [JsonProperty("charge")]
        public string Charge { get; set; }
    }
}
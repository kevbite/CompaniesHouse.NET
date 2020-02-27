using Newtonsoft.Json;

namespace CompaniesHouse.Core.Response.Insolvency
{
    public class Links
    {
        [JsonProperty("charge")]
        public string Charge { get; set; }
    }
}
using Newtonsoft.Json;

namespace CompaniesHouse.Response.Charges
{
    public class Links
    {
        [JsonProperty("self")]
        public string Self { get; set; }
    }
}
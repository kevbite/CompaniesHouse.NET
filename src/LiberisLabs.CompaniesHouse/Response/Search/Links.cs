using Newtonsoft.Json;

namespace LiberisLabs.CompaniesHouse.Response.Search
{
    public class Links
    {
        [JsonProperty(PropertyName = "self")]
        public string Self { get; set; }
    }
}
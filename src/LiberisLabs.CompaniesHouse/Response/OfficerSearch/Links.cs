using Newtonsoft.Json;

namespace LiberisLabs.CompaniesHouse.Response.OfficerSearch
{
    public class Links
    {
        [JsonProperty(PropertyName = "self")]
        public string Self { get; set; }
    }
}
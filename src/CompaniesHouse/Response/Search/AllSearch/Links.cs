using Newtonsoft.Json;

namespace CompaniesHouse.Response.Search.AllSearch
{
    public class Links
    {
        [JsonProperty(PropertyName = "self")]
        public string Self { get; set; }
    }
}
using Newtonsoft.Json;

namespace CompaniesHouse.Response.DocumentMetadata
{
    public class Links
    {
        [JsonProperty("self")]
        public string Self { get; set; }
        [JsonProperty("document")]
        public string Document { get; set; }
    }
}
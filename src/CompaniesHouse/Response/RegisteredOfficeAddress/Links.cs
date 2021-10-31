using Newtonsoft.Json;

namespace CompaniesHouse.Response.RegisteredOfficeAddress
{
    public class Links
    {
        [JsonProperty(PropertyName = "self")]
        public string Self { get; set; }
    }
}
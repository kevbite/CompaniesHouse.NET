using Newtonsoft.Json;

namespace CompaniesHouse.Response.PersonsWithSignificantControl
{
    public class PersonWithSignificantControlLinks
    {
        [JsonProperty(PropertyName = "self")]
        public string Self { get; set; }

        [JsonProperty(PropertyName = "statement")]
        public string Statement { get; set; }
    }
}

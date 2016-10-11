using Newtonsoft.Json;

namespace LiberisLabs.CompaniesHouse.Response.DisqualifiedOfficersSearch
{
    public class Links
    {
        [JsonProperty(PropertyName = "self")]
        public string Self { get; set; }
    }
}
using Newtonsoft.Json;

namespace CompaniesHouse.Core.Response.Search.DisqualifiedOfficersSearch
{
    public class Match
    {
        [JsonProperty(PropertyName = "address_snippet")]
        public string[] AddressSnippet { get; set; }

        [JsonProperty(PropertyName = "snippet")]
        public string[] Snippet { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string[] Title { get; set; }
    }
}
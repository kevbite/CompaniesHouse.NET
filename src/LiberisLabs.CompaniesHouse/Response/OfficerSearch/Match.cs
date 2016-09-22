using Newtonsoft.Json;

namespace LiberisLabs.CompaniesHouse.Response.OfficerSearch
{
    public class Match
    {
        [JsonProperty(PropertyName = "address_snippet")]
        public int[] AddressSnippet { get; set; }

        [JsonProperty(PropertyName = "snippet")]
        public int[] Snippet { get; set; }

        [JsonProperty(PropertyName = "title")]
        public int[] Title { get; set; }
    }
}
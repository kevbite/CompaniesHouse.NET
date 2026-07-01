using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.AllSearch
{
    public class Matches
    {
        [JsonPropertyName("address_snippet")]
        public string[] AddressSnippet { get; set; }
        [JsonPropertyName("snippet")]
        public string[] Snippet { get; set; }
        [JsonPropertyName("title")]
        public string[] Title { get; set; }
    }
}

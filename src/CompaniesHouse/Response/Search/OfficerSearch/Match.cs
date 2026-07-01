using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.OfficerSearch
{
    public class Match
    {
        [JsonPropertyName("address_snippet")]
        public int[] AddressSnippet { get; set; }

        [JsonPropertyName("snippet")]
        public int[] Snippet { get; set; }

        [JsonPropertyName("title")]
        public int[] Title { get; set; }
    }
}

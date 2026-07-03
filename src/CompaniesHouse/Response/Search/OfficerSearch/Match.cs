using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.OfficerSearch
{
    public class Match
    {
        [JsonPropertyName("address_snippet")]
        public int[] AddressSnippet { get; set; } = null!;

        [JsonPropertyName("snippet")]
        public int[] Snippet { get; set; } = null!;

        [JsonPropertyName("title")]
        public int[] Title { get; set; } = null!;
    }
}

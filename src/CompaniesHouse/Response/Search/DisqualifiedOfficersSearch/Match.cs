using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.DisqualifiedOfficersSearch
{
    public class Match
    {
        [JsonPropertyName("address_snippet")]
        public string[] AddressSnippet { get; set; } = null!;

        [JsonPropertyName("snippet")]
        public string[] Snippet { get; set; } = null!;

        [JsonPropertyName("title")]
        public string[] Title { get; set; } = null!;
    }
}

using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.CompanySearch
{
    public class Matches
    {
        [JsonPropertyName("address_snippet")]
        public int[]? AddressSnippet { get; set; }

        [JsonPropertyName("snippet")]
        public int[]? Snippet { get; set; }

        [JsonPropertyName("title")]
        public int[]? Title { get; set; }
    }

}

using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search
{
    public class UnknownSearchItem : SearchItem
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}

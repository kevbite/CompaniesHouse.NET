using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search
{
    public class Links
    {
        [JsonPropertyName("self")]
        public string? Self { get; set; }
    }
}

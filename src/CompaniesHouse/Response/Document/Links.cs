using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Document
{
    public class Links
    {
        [JsonPropertyName("self")]
        public string? Self { get; set; }
        [JsonPropertyName("document")]
        public string? Document { get; set; }
    }
}

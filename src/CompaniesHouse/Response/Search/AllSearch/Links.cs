using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.AllSearch
{
    public class Links
    {
        [JsonPropertyName("self")]
        public string Self { get; set; } = null!;
    }
}

using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Officers
{
    public class OfficersListLinks
    {
        [JsonPropertyName("self")]
        public string? Self { get; set; }
    }
}

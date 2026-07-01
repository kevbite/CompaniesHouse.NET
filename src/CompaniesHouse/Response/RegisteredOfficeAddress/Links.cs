using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.RegisteredOfficeAddress
{
    public class Links
    {
        [JsonPropertyName("self")]
        public string? Self { get; set; }
    }
}

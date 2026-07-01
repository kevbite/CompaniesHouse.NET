using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Charges
{
    public class Links
    {
        [JsonPropertyName("self")]
        public string? Self { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Insolvency
{
    public class Links
    {
        [JsonPropertyName("charge")]
        public string? Charge { get; set; }
    }
}

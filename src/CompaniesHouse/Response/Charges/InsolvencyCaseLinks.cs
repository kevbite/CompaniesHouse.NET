using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Charges
{
    public class InsolvencyCaseLinks
    {
        [JsonPropertyName("case")]
        public string? Case { get; set; }
    }
}

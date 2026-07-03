using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Registers
{
    public class CompanyRegisters
    {
        [JsonPropertyName("links")]
        public CompanyRegistersLinks Links { get; set; } = new();

        [JsonPropertyName("company_number")]
        public string? CompanyNumber { get; set; }

        [JsonPropertyName("kind")]
        public string Kind { get; set; } = string.Empty;

        [JsonPropertyName("registers")]
        public CompanyRegistersEntries Registers { get; set; } = new();

        [JsonPropertyName("etag")]
        public string? Etag { get; set; }
    }
}

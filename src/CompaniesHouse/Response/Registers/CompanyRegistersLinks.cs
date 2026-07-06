using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Registers
{
    public class CompanyRegistersLinks
    {
        [JsonPropertyName("self")]
        public string Self { get; set; } = string.Empty;
    }
}

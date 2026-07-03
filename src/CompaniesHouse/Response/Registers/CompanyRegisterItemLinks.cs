using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Registers
{
    public class CompanyRegisterItemLinks
    {
        [JsonPropertyName("filing")]
        public string Filing { get; set; } = string.Empty;
    }
}

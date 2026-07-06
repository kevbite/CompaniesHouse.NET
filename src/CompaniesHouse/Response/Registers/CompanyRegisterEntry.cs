using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Registers
{
    public class CompanyRegisterEntry
    {
        [JsonPropertyName("register_type")]
        public string RegisterType { get; set; } = string.Empty;

        [JsonPropertyName("items")]
        public CompanyRegisterItem[] Items { get; set; } = [];

        [JsonPropertyName("links")]
        public CompanyRegisterEntryLinks? Links { get; set; }
    }
}

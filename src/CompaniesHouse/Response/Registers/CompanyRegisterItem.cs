using System;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Registers
{
    public class CompanyRegisterItem
    {
        [JsonPropertyName("moved_on")]
        public DateTime MovedOn { get; set; }

        [JsonPropertyName("register_moved_to")]
        public string RegisterMovedTo { get; set; } = string.Empty;

        [JsonPropertyName("links")]
        public CompanyRegisterItemLinks? Links { get; set; }
    }
}

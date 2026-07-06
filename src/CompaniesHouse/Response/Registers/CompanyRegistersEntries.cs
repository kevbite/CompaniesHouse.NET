using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Registers
{
    public class CompanyRegistersEntries
    {
        [JsonPropertyName("directors")]
        public CompanyRegisterEntry? Directors { get; set; }

        [JsonPropertyName("secretaries")]
        public CompanyRegisterEntry? Secretaries { get; set; }

        [JsonPropertyName("persons_with_significant_control")]
        public CompanyRegisterEntry? PersonsWithSignificantControl { get; set; }

        [JsonPropertyName("usual_residential_address")]
        public CompanyRegisterEntry? UsualResidentialAddress { get; set; }

        [JsonPropertyName("llp_usual_residential_address")]
        public CompanyRegisterEntry? LlpUsualResidentialAddress { get; set; }

        [JsonPropertyName("members")]
        public CompanyRegisterEntry? Members { get; set; }

        [JsonPropertyName("llp_members")]
        public CompanyRegisterEntry? LlpMembers { get; set; }
    }
}

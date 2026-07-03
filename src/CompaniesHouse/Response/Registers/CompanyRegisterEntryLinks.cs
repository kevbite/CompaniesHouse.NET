using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Registers
{
    public class CompanyRegisterEntryLinks
    {
        [JsonPropertyName("directors_register")]
        public string? DirectorsRegister { get; set; }

        [JsonPropertyName("secretaries_register")]
        public string? SecretariesRegister { get; set; }

        [JsonPropertyName("persons_with_significant_control_register")]
        public string? PersonsWithSignificantControlRegister { get; set; }

        [JsonPropertyName("usual_residential_address")]
        public string? UsualResidentialAddress { get; set; }

        [JsonPropertyName("llp_usual_residential_address")]
        public string? LlpUsualResidentialAddress { get; set; }

        [JsonPropertyName("members")]
        public string? Members { get; set; }

        [JsonPropertyName("llp_members")]
        public string? LlpMembers { get; set; }
    }
}

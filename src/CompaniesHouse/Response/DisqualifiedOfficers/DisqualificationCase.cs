using System;
using System.Text.Json.Serialization;
using CompaniesHouse.Response;

namespace CompaniesHouse.Response.DisqualifiedOfficers
{
    public class DisqualificationCase
    {
        [JsonPropertyName("case_identifier")]
        public string? CaseIdentifier { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; } = new();

        [JsonPropertyName("company_names")]
        public string[]? CompanyNames { get; set; }

        [JsonPropertyName("court_name")]
        public string? CourtName { get; set; }

        [JsonPropertyName("disqualification_type")]
        public string DisqualificationType { get; set; } = string.Empty;

        [JsonPropertyName("disqualified_from")]
        public DateTime DisqualifiedFrom { get; set; }

        [JsonPropertyName("disqualified_until")]
        public DateTime DisqualifiedUntil { get; set; }

        [JsonPropertyName("heard_on")]
        public DateTime? HeardOn { get; set; }

        [JsonPropertyName("undertaken_on")]
        public DateTime? UndertakenOn { get; set; }

        [JsonPropertyName("last_variation")]
        public DisqualificationLastVariation[]? LastVariation { get; set; }

        [JsonPropertyName("reason")]
        public DisqualificationReason Reason { get; set; } = new();
    }
}

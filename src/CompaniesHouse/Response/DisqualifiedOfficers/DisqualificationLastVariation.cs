using System;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.DisqualifiedOfficers
{
    public class DisqualificationLastVariation
    {
        [JsonPropertyName("varied_on")]
        public DateTime? VariedOn { get; set; }

        [JsonPropertyName("case_identifier")]
        public string? CaseIdentifier { get; set; }

        [JsonPropertyName("court_name")]
        public string? CourtName { get; set; }
    }
}

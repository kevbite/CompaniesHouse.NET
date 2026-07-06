using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Insolvency
{
    public class Case
    {
        [JsonPropertyName("dates")]
        public CaseDate[]? Dates { get; set; }

        [JsonPropertyName("links")]
        public Links? Links { get; set; }

        [JsonPropertyName("notes")]
        public string[]? Notes { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("practitioners")]
        public Practitioner[]? Practitioners { get; set; }

        [JsonPropertyName("type")]
        public InsolvencyCaseType Type { get; set; }
    }
}

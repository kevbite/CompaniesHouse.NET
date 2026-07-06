using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.DisqualifiedOfficers
{
    public class DisqualificationReason
    {
        [JsonPropertyName("description_identifier")]
        public string DescriptionIdentifier { get; set; } = string.Empty;

        [JsonPropertyName("act")]
        public string Act { get; set; } = string.Empty;

        [JsonPropertyName("article")]
        public string? Article { get; set; }

        [JsonPropertyName("section")]
        public string? Section { get; set; }
    }
}

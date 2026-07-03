using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.DisqualifiedOfficers
{
    public class DisqualificationLinks
    {
        [JsonPropertyName("self")]
        public string Self { get; set; } = string.Empty;
    }
}

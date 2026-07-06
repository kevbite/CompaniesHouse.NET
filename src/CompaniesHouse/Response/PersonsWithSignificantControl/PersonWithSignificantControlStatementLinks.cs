using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.PersonsWithSignificantControl
{
    public class PersonWithSignificantControlStatementLinks
    {
        [JsonPropertyName("self")]
        public string Self { get; set; } = string.Empty;

        [JsonPropertyName("person_with_significant_control")]
        public string? PersonWithSignificantControl { get; set; }
    }
}

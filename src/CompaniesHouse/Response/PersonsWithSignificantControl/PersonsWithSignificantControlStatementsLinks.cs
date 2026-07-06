using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.PersonsWithSignificantControl
{
    public class PersonsWithSignificantControlStatementsLinks
    {
        [JsonPropertyName("self")]
        public string Self { get; set; } = string.Empty;

        [JsonPropertyName("persons_with_significant_control_statements_list")]
        public string? PersonsWithSignificantControlStatementsList { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.PersonsWithSignificantControl
{
    public class PersonWithSignificantControlLinks
    {
        [JsonPropertyName("self")]
        public string? Self { get; set; }

        [JsonPropertyName("statement")]
        public string? Statement { get; set; }
    }
}

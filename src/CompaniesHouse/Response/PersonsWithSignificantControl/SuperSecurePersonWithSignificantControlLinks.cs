using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.PersonsWithSignificantControl
{
    public class SuperSecurePersonWithSignificantControlLinks
    {
        [JsonPropertyName("self")]
        public string Self { get; set; } = string.Empty;
    }
}

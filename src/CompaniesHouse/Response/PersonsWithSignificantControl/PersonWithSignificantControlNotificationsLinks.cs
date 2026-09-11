using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.PersonsWithSignificantControl
{
    public class PersonWithSignificantControlNotificationsLinks
    {
        [JsonPropertyName("self")]
        public string? Self { get; set; }
    }
}

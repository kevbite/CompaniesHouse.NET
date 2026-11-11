using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.PersonsWithSignificantControl
{
    public class PersonWithSignificantControlNotificationLinks
    {
        [JsonPropertyName("company")]
        public string? Company { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.PersonsWithSignificantControl
{
    public class PersonsWithSignificantControl
    {
        [JsonPropertyName("active_count")]
        public int? ActiveCount { get; set; }

        [JsonPropertyName("items")]
        public PersonWithSignificantControl[] Items { get; set; }

        [JsonPropertyName("ceased_count")]
        public int? CeasedCount { get; set; }
    }
}

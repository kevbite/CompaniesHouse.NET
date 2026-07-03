using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Appointments
{
    public class NameElements
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("forename")]
        public string? Forename { get; set; }

        [JsonPropertyName("surname")]
        public string? Surname { get; set; }

        [JsonPropertyName("other_forenames")]
        public string? OtherForenames { get; set; }

    }
}

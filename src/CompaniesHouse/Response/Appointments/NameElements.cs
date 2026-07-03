using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Appointments
{
    public class NameElements
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;

        [JsonPropertyName("forename")]
        public string Forename { get; set; } = null!;

        [JsonPropertyName("surname")]
        public string Surname { get; set; } = null!;

        [JsonPropertyName("other_forenames")]
        public string OtherForenames { get; set; } = null!;

    }
}

using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Officers
{
    public class OfficerFormerName
    {
        [JsonPropertyName("forenames")]
        public string ForeNames { get; set; } = null!;

        [JsonPropertyName("surname")]
        public string Surname { get; set; } = null!;
    }
}

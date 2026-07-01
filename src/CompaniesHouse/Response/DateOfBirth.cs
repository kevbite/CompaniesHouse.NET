using System.Text.Json.Serialization;

namespace CompaniesHouse.Response
{
    public class DateOfBirth
    {
        [JsonPropertyName("day")]
        public int? Day { get; set; }

        [JsonPropertyName("month")]
        public int? Month { get; set; }

        [JsonPropertyName("year")]
        public int? Year { get; set; }
    }
}

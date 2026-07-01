using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Charges
{
    public class PersonEntitled
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}

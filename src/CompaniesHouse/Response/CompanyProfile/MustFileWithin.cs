using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class MustFileWithin
    {
        [JsonPropertyName("months")]
        public string? Months { get; set; }
    }
}

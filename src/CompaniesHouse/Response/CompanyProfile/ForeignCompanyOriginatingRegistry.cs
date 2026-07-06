using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class ForeignCompanyOriginatingRegistry
    {
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}

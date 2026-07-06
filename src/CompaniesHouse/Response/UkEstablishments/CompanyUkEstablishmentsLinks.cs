using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.UkEstablishments
{
    public class CompanyUkEstablishmentsLinks
    {
        [JsonPropertyName("self")]
        public string Self { get; set; } = string.Empty;
    }
}

using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.UkEstablishments
{
    public class CompanyUkEstablishmentLinks
    {
        [JsonPropertyName("company")]
        public string Company { get; set; } = string.Empty;
    }
}

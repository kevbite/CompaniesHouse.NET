using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search
{
    public class CompanyProfileLinks
    {
        [JsonPropertyName("company_profile")]
        public string CompanyProfile { get; set; }
    }
}

using System.Text.Json.Serialization;
using CompaniesHouse.Response;

namespace CompaniesHouse.Response.Search.CompaniesAlphabeticallySearch
{
    public class Company
    {
        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; } = null!;

        [JsonPropertyName("company_number")]
        public string CompanyNumber { get; set; } = null!;

        [JsonPropertyName("company_status")]
        public CompanyStatus CompanyStatus { get; set; }

        [JsonPropertyName("company_type")]
        public CompanyType CompanyType { get; set; }

        [JsonPropertyName("kind")]
        public string Kind { get; set; } = null!;

        [JsonPropertyName("links")]
        public global::CompaniesHouse.Response.Search.CompanyProfileLinks Links { get; set; } = null!;

        [JsonPropertyName("ordered_alpha_key_with_id")]
        public string OrderedAlphaKeyWithId { get; set; } = null!;
    }
}

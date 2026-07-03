using System;
using System.Text.Json.Serialization;
using CompaniesHouse.Response;

namespace CompaniesHouse.Response.Search.DissolvedCompaniesSearch
{
    public class Company
    {
        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; } = string.Empty;

        [JsonPropertyName("company_number")]
        public string CompanyNumber { get; set; } = string.Empty;

        [JsonPropertyName("company_status")]
        public CompanyStatus CompanyStatus { get; set; }

        [JsonPropertyName("date_of_cessation")]
        public DateTime DateOfCessation { get; set; }

        [JsonPropertyName("date_of_creation")]
        public DateTime DateOfCreation { get; set; }

        [JsonPropertyName("kind")]
        public string? Kind { get; set; }

        [JsonPropertyName("matched_previous_company_name")]
        public PreviousCompanyName? MatchedPreviousCompanyName { get; set; }

        [JsonPropertyName("ordered_alpha_key_with_id")]
        public string? OrderedAlphaKeyWithId { get; set; }

        [JsonPropertyName("previous_company_names")]
        public PreviousCompanyName[]? PreviousCompanyNames { get; set; }

        [JsonPropertyName("registered_office_address")]
        public Address? RegisteredOfficeAddress { get; set; }
    }
}

using System;
using System.Text.Json.Serialization;
using CompaniesHouse.JsonConverters;
using CompaniesHouse.Response;

namespace CompaniesHouse.Response.Search.AdvancedCompanySearch
{
    public class Company
    {
        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; } = null!;

        [JsonPropertyName("company_number")]
        public string CompanyNumber { get; set; } = null!;

        [JsonPropertyName("company_status")]
        public CompanyStatus CompanyStatus { get; set; }

        [JsonPropertyName("company_subtype")]
        public CompanySubtype? CompanySubtype { get; set; }

        [JsonPropertyName("company_type")]
        public CompanyType CompanyType { get; set; }

        [JsonPropertyName("date_of_cessation")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? DateOfCessation { get; set; }

        [JsonPropertyName("date_of_creation")]
        public DateTime? DateOfCreation { get; set; }

        [JsonPropertyName("kind")]
        public string Kind { get; set; } = null!;

        [JsonPropertyName("links")]
        public global::CompaniesHouse.Response.Search.CompanyProfileLinks Links { get; set; } = null!;

        [JsonPropertyName("registered_office_address")]
        public Address? RegisteredOfficeAddress { get; set; }

        [JsonPropertyName("sic_codes")]
        public string[]? SicCodes { get; set; }
    }
}

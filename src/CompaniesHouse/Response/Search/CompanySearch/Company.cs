using System;
using CompaniesHouse.JsonConverters;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.CompanySearch
{
    public class Company : SearchItem
    {
        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("company_number")]
        public string CompanyNumber { get; set; }

        [JsonPropertyName("company_status")]
        public CompanyStatus CompanyStatus { get; set; }

        [JsonPropertyName("company_type")]
        public CompanyType CompanyType { get; set; }

        [JsonPropertyName("date_of_cessation")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? DateOfCessation { get; set; }

        [JsonPropertyName("date_of_creation")]
        public DateTime? DateOfCreation { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("description_identifier")]
        public object[] DescriptionIdentifier { get; set; }

        [JsonPropertyName("matches")]
        public Matches Matches { get; set; }

        [JsonPropertyName("snippet")]
        public string Snippet { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}

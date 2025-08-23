using System;
using CompaniesHouse.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CompaniesHouse.Response.Search.CompanySearch
{
    public class Company : SearchItem
    {
        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }

        [JsonProperty(PropertyName = "company_number")]
        public string CompanyNumber { get; set; }

        [JsonProperty(PropertyName = "company_status")]
        [JsonConverter(typeof(OptionalStringEnumConverter<CompanyStatus>), CompanyStatus.None)]
        public CompanyStatus CompanyStatus { get; set; }

        [JsonProperty(PropertyName = "company_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CompanyType CompanyType { get; set; }
        
        [JsonProperty(PropertyName = "company_subtype")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CompanySubType CompanySubType { get; set; }
        
        [JsonProperty(PropertyName = "date_of_cessation")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? DateOfCessation { get; set; }

        [JsonProperty(PropertyName = "date_of_creation")]
        public DateTime? DateOfCreation { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "description_identifier")]
        public object[] DescriptionIdentifier { get; set; }

        [JsonProperty(PropertyName = "matches")]
        public Matches Matches { get; set; }

        [JsonProperty(PropertyName = "snippet")]
        public string Snippet { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}
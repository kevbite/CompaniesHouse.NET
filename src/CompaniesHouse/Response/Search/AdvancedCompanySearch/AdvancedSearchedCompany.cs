using CompaniesHouse.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CompaniesHouse.Response.Search.AdvancedCompanySearch;

public class AdvancedSearchedCompany : SearchItem
{
    [JsonProperty(PropertyName = "company_name")]
    public string CompanyName { get; set; }
        
    [JsonProperty(PropertyName = "registered_office_address")]
    public Address RegisteredOfficeAddress { get; set; }

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

    [JsonProperty(PropertyName = "sic_codes")]
    public string[] SicCodes { get; set; }
}
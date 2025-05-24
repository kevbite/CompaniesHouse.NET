using CompaniesHouse.JsonConverters;
using Newtonsoft.Json;

namespace CompaniesHouse.Response.CompanyProfile;

public class AccountingRequirement
{
    [JsonProperty("foreign_account_type")]
    [JsonConverter(typeof(OptionalStringEnumConverter<ForeignAccountType>), ForeignAccountType.None)]
    public ForeignAccountType ForeignAccountType { get; set; }

    [JsonProperty("terms_of_account_publication")]
    [JsonConverter(typeof(OptionalStringEnumConverter<TermsOfAccountPublication>), TermsOfAccountPublication.None)]
    public TermsOfAccountPublication TermsOfAccountPublication { get; set; }
}
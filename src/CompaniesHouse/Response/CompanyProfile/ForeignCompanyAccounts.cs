using Newtonsoft.Json;

namespace CompaniesHouse.Response.CompanyProfile;

public class ForeignCompanyAccounts
{
    [JsonProperty("account_period_from:")]
    public ForeignCompanyPeriodFrom AccountPeriodFrom { get; set; }

    [JsonProperty("account_period_to")]
    public ForeignCompanyPeriodTo AccountPeriodTo { get; set; }

    [JsonProperty("must_file_within")]
    public MustFileWithin MustFileWithin { get; set; }
}
using Newtonsoft.Json;

namespace CompaniesHouse.Response.CompanyProfile;

public class ForeignCompanyPeriodTo
{
    [JsonProperty("day")]
    public int? Day { get; set; }

    [JsonProperty("month")]
    public int? Month { get; set; }
}
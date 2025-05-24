using Newtonsoft.Json;

namespace CompaniesHouse.Response.CompanyProfile;

public class ForeignCompanyPeriodFrom
{
    [JsonProperty("day")]
    public int? Day { get; set; }

    [JsonProperty("month")]
    public int? Month { get; set; }
}
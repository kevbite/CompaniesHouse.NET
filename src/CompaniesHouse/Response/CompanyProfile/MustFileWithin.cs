using Newtonsoft.Json;

namespace CompaniesHouse.Response.CompanyProfile;

public class MustFileWithin
{
    [JsonProperty("months")]
    public int? Months { get; set; }
}
using Newtonsoft.Json;

namespace CompaniesHouse.Response.CompanyProfile;

public class OriginatingRegistry
{
    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}
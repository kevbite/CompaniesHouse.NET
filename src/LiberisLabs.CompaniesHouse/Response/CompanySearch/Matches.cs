using Newtonsoft.Json;

namespace LiberisLabs.CompaniesHouse.Response.CompanySearch
{
    public class Matches
    {
        [JsonProperty(PropertyName = "title")]
        public object[] Title { get; set; }
    }

}

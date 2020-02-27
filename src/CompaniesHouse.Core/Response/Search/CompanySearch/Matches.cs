using Newtonsoft.Json;

namespace CompaniesHouse.Core.Response.Search.CompanySearch
{
    public class Matches
    {
        [JsonProperty(PropertyName = "title")]
        public int[] Title { get; set; }
    }

}

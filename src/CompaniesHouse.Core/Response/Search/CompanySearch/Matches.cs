using Newtonsoft.Json;

namespace CompaniesHouse.Response.Search.CompanySearch
{
    public class Matches
    {
        [JsonProperty(PropertyName = "title")]
        public int[] Title { get; set; }
    }

}

using LiberisLabs.CompaniesHouse.JsonConverters;
using LiberisLabs.CompaniesHouse.Response.Search.CompanySearch;
using Newtonsoft.Json;

namespace LiberisLabs.CompaniesHouse.Response.Search
{
    [JsonConverter(typeof(SearchItemConverter))]
    public abstract class SearchItem
    {
        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }

        [JsonProperty(PropertyName = "links")]
        public Links Links { get; set; }
    }
}

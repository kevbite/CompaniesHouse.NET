using CompaniesHouse.Core.JsonConverters;
using CompaniesHouse.Core.Response.Search.CompanySearch;
using Newtonsoft.Json;

namespace CompaniesHouse.Core.Response.Search
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

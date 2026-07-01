using CompaniesHouse.JsonConverters;
using CompaniesHouse.Response.Search.CompanySearch;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search
{
    [JsonConverter(typeof(SearchItemConverter))]
    public abstract class SearchItem
    {
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("links")]
        public Links Links { get; set; }
    }
}

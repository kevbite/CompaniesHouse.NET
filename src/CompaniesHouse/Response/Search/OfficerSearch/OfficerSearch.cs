using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.OfficerSearch
{

    public class OfficerSearch
    {
        [JsonPropertyName("items")]
        public Officer[] Officers { get; set; }

        [JsonPropertyName("items_per_page")]
        public int ItemsPerPage { get; set; }

        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("start_index")]
        public int StartIndex { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.DisqualifiedOfficersSearch
{
    public class DisqualifiedOfficerSearch
    {
        [JsonPropertyName("items")]
        public DisqualifiedOfficer[] DisqualifiedOfficers { get; set; }

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

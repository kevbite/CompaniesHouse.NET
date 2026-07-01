using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.PersonsWithSignificantControl
{
    public class PersonsWithSignificantControl
    {
        [JsonPropertyName("active_count")]
        public int? ActiveCount { get; set; }

        [JsonPropertyName("items")]
        public PersonWithSignificantControl[]? Items { get; set; }

        [JsonPropertyName("ceased_count")]
        public int? CeasedCount { get; set; }

        [JsonPropertyName("items_per_page")]
        public int? ItemsPerPage { get; set; }

        [JsonPropertyName("links")]
        public PersonWithSignificantControlLinks? Links { get; set; }

        [JsonPropertyName("start_index")]
        public int? StartIndex { get; set; }

        [JsonPropertyName("total_results")]
        public int? TotalResults { get; set; }
    }
}

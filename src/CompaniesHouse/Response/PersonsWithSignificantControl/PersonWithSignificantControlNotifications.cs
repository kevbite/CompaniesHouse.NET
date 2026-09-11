using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.PersonsWithSignificantControl
{
    public class PersonWithSignificantControlNotifications
    {
        [JsonPropertyName("active_count")]
        public int? ActiveCount { get; set; }

        [JsonPropertyName("ceased_count")]
        public int? CeasedCount { get; set; }

        [JsonPropertyName("inactive_count")]
        public int? InactiveCount { get; set; }

        [JsonPropertyName("items")]
        public PersonWithSignificantControlNotification[]? Items { get; set; }

        [JsonPropertyName("items_per_page")]
        public int? ItemsPerPage { get; set; }

        [JsonPropertyName("date_of_birth")]
        public DateOfBirth? DateOfBirth { get; set; }

        [JsonPropertyName("kind")]
        public PersonWithSignificantControlNotificationKind Kind { get; set; }

        [JsonPropertyName("links")]
        public PersonWithSignificantControlNotificationsLinks? Links { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("start_index")]
        public int? StartIndex { get; set; }

        [JsonPropertyName("total_results")]
        public int? TotalResults { get; set; }
    }
}

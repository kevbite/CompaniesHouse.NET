using System.Collections.Generic;
using System.Text;
using CompaniesHouse.Response.Search.OfficerSearch;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Appointments
{
    public class Appointments
    {
        [JsonPropertyName("active_count")]
        public int ActiveCount { get; set; }

        [JsonPropertyName("etag")]
        public string? ETag { get; set; }

        [JsonPropertyName("inactive_count")]
        public int InactiveCount { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }

        [JsonPropertyName("kind")]
        public string? Kind { get; set; }

        [JsonPropertyName("is_corporate_officer")]
        public bool IsCorporateOfficer { get; set; }

        [JsonPropertyName("date_of_birth")]
        public DateOfBirth? DateOfBirth { get; set; }

        [JsonPropertyName("items")]
        public Appointment[]? Items { get; set; }

        [JsonPropertyName("items_per_page")]
        public int ItemsPerPage { get; set; }

        [JsonPropertyName("links")]
        public AppointmentsLinks? Links { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("resigned_count")]
        public int ResignedCount { get; set; }

        [JsonPropertyName("start_index")]
        public int StartIndex { get; set; }
    }
}

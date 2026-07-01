using System.Collections.Generic;
using System.Text;
using CompaniesHouse.Response.Search.OfficerSearch;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Appointments
{
    public class Appointments
    {
        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }

        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("is_corporate_officer")]
        public bool IsCorporateOfficer { get; set; }

        [JsonPropertyName("date_of_birth")]
        public DateOfBirth DateOfBirth { get; set; }

        [JsonPropertyName("items")]
        public Appointment[] Items { get; set; }

    }
}

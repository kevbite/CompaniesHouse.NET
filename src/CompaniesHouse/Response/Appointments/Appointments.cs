using System.Collections.Generic;
using System.Text;
using CompaniesHouse.Response.Search.OfficerSearch;
using Newtonsoft.Json;

namespace CompaniesHouse.Response.Appointments
{
    public class Appointments
    {
        [JsonProperty(PropertyName = "total_results")]
        public string TotalResults { get; set; }

        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }

        [JsonProperty(PropertyName = "is_corporate_officer")]
        public bool IsCorporateOfficer { get; set; }

        [JsonProperty(PropertyName = "date_of_birth")]
        public DateOfBirth DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "items")]
        public Appointment[] Items { get; set; }

    }
}

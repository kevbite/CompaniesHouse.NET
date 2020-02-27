using System.Collections.Generic;
using System.Text;
using CompaniesHouse.Core.Response.Search.OfficerSearch;
using Newtonsoft.Json;

namespace CompaniesHouse.Core.Response.Appointments
{
    public class Appointments
    {
        [JsonProperty(PropertyName = "total_results")]
        public int TotalResults { get; set; }

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

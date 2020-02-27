using Newtonsoft.Json;

namespace CompaniesHouse.Core.Response.Appointments
{
    public class AppointedTo
    {
        [JsonProperty(PropertyName = "company_status")]
        public string CompanyStatus { get; set; }

        [JsonProperty(PropertyName = "company_number")]
        public string CompanyNumber { get; set; }

        [JsonProperty(PropertyName = "company_name")]
        public string CompanyName { get; set; }

    }
}
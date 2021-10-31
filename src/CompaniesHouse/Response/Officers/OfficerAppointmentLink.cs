using Newtonsoft.Json;

namespace CompaniesHouse.Response.Officers
{
    public class OfficerAppointmentLink
    {
        [JsonProperty(PropertyName = "appointments")]
        public string AppointmentsResource { get; set; }
    }
}
using Newtonsoft.Json;

namespace CompaniesHouse.Response.Officers
{
    public class OfficerAppointmentLink
    {
        [JsonProperty(PropertyName = "appointments")]
        public string AppointmentsResource { get; set; }

        public string OfficerId => AppointmentsResource?.Split('/')[2];
    }
}
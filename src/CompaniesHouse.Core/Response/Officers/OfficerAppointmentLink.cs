using Newtonsoft.Json;

namespace CompaniesHouse.Core.Response.Officers
{
    public class OfficerAppointmentLink
    {
        [JsonProperty(PropertyName = "appointments")]
        public string AppointmentsResource { get; set; }

        public string OfficerId
        {
            get { return AppointmentsResource.Split('/')[2]; }
        }       
    }
}
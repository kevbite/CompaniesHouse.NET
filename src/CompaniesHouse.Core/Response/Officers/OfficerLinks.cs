using Newtonsoft.Json;

namespace CompaniesHouse.Core.Response.Officers
{
    public class OfficerLinks
    {
        [JsonProperty(PropertyName = "officer")]
        public OfficerAppointmentLink Officer { get; set; }
    }
}
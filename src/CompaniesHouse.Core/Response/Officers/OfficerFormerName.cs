using Newtonsoft.Json;

namespace CompaniesHouse.Response.Officers
{
    public class OfficerFormerName
    {
        [JsonProperty(PropertyName = "forenames")]
        public string ForeNames { get; set; }

        [JsonProperty(PropertyName = "surname")]
        public string Surname { get; set; }
    }
}
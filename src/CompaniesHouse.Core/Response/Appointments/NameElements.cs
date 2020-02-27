using Newtonsoft.Json;

namespace CompaniesHouse.Response.Appointments
{
    public class NameElements
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "forename")]
        public string Forename { get; set; }

        [JsonProperty(PropertyName = "surname")]
        public string Surname { get; set; }

        [JsonProperty(PropertyName = "other_forenames")]
        public string OtherForenames { get; set; }

    }
}
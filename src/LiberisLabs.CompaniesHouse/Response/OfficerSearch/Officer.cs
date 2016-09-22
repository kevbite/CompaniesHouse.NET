using Newtonsoft.Json;

namespace LiberisLabs.CompaniesHouse.Response.OfficerSearch
{
    public class Officer
    {
        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }

        [JsonProperty(PropertyName = "address_snippet")]
        public string AddressSnippet { get; set; }

        [JsonProperty(PropertyName = "appointment_count")]
        public int AppointmentCount { get; set; }

        [JsonProperty(PropertyName = "date_of_birth")]
        public DateOfBirth DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "description_identifiers")]
        public string[] DescriptionIdentifiers { get; set; }

        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }

        [JsonProperty(PropertyName = "links")]
        public Links Links { get; set; }

        [JsonProperty(PropertyName = "matches")]
        public Match Matches { get; set; }

        [JsonProperty(PropertyName = "snippet")]
        public string Snippet { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}
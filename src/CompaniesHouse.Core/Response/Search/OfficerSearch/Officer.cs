using Newtonsoft.Json;

namespace CompaniesHouse.Core.Response.Search.OfficerSearch
{
    public class Officer : SearchItem
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

        [JsonProperty(PropertyName = "matches")]
        public Match Matches { get; set; }

        [JsonProperty(PropertyName = "snippet")]
        public string Snippet { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        public string OfficerId
        {
            get { return Links.Self.Split('/')[2]; }
        }
    }
}
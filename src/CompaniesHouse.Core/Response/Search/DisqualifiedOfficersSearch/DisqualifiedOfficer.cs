using System;
using Newtonsoft.Json;

namespace CompaniesHouse.Response.Search.DisqualifiedOfficersSearch
{
    public class DisqualifiedOfficer : SearchItem
    {
        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }

        [JsonProperty(PropertyName = "address_snippet")]
        public string AddressSnippet { get; set; }

        [JsonProperty(PropertyName = "date_of_birth")]
        public DateTime DateOfBirth { get; set; }

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
    }
}
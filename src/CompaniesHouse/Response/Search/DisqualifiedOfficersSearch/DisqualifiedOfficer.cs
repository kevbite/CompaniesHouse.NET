using System;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.DisqualifiedOfficersSearch
{
    public class DisqualifiedOfficer : SearchItem
    {
        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("address_snippet")]
        public string AddressSnippet { get; set; }

        [JsonPropertyName("date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("description_identifiers")]
        public string[] DescriptionIdentifiers { get; set; }

        [JsonPropertyName("matches")]
        public Match Matches { get; set; }

        [JsonPropertyName("snippet")]
        public string Snippet { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}

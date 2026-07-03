using System;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.DisqualifiedOfficersSearch
{
    public class DisqualifiedOfficer : SearchItem
    {
        [JsonPropertyName("address")]
        public Address Address { get; set; } = null!;

        [JsonPropertyName("address_snippet")]
        public string AddressSnippet { get; set; } = null!;

        [JsonPropertyName("date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

        [JsonPropertyName("description_identifiers")]
        public string[] DescriptionIdentifiers { get; set; } = null!;

        [JsonPropertyName("matches")]
        public Match Matches { get; set; } = null!;

        [JsonPropertyName("snippet")]
        public string Snippet { get; set; } = null!;

        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;
    }
}

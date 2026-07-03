using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.OfficerSearch
{
    public class Officer : SearchItem
    {
        [JsonPropertyName("address")]
        public Address? Address { get; set; }

        [JsonPropertyName("address_snippet")]
        public string? AddressSnippet { get; set; }

        [JsonPropertyName("appointment_count")]
        public int AppointmentCount { get; set; }

        [JsonPropertyName("date_of_birth")]
        public DateOfBirth? DateOfBirth { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("description_identifiers")]
        public string[]? DescriptionIdentifiers { get; set; }

        [JsonPropertyName("matches")]
        public Match? Matches { get; set; }

        [JsonPropertyName("snippet")]
        public string? Snippet { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        public string? OfficerId
        {
            get
            {
                var self = Links?.Self;
                if (string.IsNullOrWhiteSpace(self))
                {
                    return null;
                }

                var parts = self.Split('/');
                return parts.Length > 2 ? parts[2] : null;
            }
        }
    }
}

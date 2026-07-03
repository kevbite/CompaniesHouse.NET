using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.UkEstablishments
{
    public class CompanyUkEstablishments
    {
        [JsonPropertyName("etag")]
        public string Etag { get; set; } = string.Empty;

        [JsonPropertyName("kind")]
        public string Kind { get; set; } = string.Empty;

        [JsonPropertyName("links")]
        public CompanyUkEstablishmentsLinks Links { get; set; } = new();

        [JsonPropertyName("items")]
        public CompanyUkEstablishment[] Items { get; set; } = [];
    }
}

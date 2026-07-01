using CompaniesHouse.JsonConverters;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Charges
{
    public class SecuredDetail
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("type")]
        public SecuredDetailType Type { get; set; }
    }
}

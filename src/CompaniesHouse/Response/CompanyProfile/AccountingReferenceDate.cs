using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class AccountingReferenceDate
    {
        [JsonPropertyName("day")]
        public int Day { get; set; }

        [JsonPropertyName("month")]
        public int Month { get; set; }
    }
}

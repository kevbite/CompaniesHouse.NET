using Newtonsoft.Json;

namespace CompaniesHouse.Core.Response.CompanyProfile
{
    public class AccountingReferenceDate
    {
        [JsonProperty(PropertyName = "day")]
        public int Day { get; set; }

        [JsonProperty(PropertyName = "month")]
        public int Month { get; set; }
    }
}
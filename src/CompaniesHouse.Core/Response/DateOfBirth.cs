using Newtonsoft.Json;

namespace CompaniesHouse.Response
{
    public class DateOfBirth
    {
        [JsonProperty(PropertyName = "day")]
        public int? Day { get; set; }

        [JsonProperty(PropertyName = "month")]
        public int? Month { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }
    }
}

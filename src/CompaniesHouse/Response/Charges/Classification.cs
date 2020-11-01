using CompaniesHouse.JsonConverters;
using Newtonsoft.Json;

namespace CompaniesHouse.Response.Charges
{
    public class Classification
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("type")]
        [JsonConverter(typeof(OptionalStringEnumConverter<ClassificationChargeType>), ClassificationChargeType.None)]
        public ClassificationChargeType Type { get; set; }
    }
}
using Newtonsoft.Json;

namespace CompaniesHouse.Core.Response.PersonsWithSignificantControl
{
    public class PersonWithSignificantControlLinks
    {
        [JsonProperty(PropertyName = "self")]
        public string Self { get; set; }

        [JsonProperty(PropertyName = "statement")]
        public string Statement { get; set; }

        public string PersonWithSignificantControlId
        {
            get { return Self.Split('/')[5]; }
        }
    }
}

using CompaniesHouse.Core.Response.PersonsWithSignificantControl;
using CompaniesHouse.Core.Response.Appointments;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using CompaniesHouse.Core.Response;

namespace CompaniesHouse.Core.Tests.ResourceBuilders
{
    public class PersonWithSignificantControl
    {
        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }

        [JsonProperty(PropertyName = "ceased_on")]
        public DateTime CeasedOn { get; set; }

        [JsonProperty(PropertyName = "country_of_residence")]
        public string CountryOfResidence { get; set; }

        [JsonProperty(PropertyName = "date_of_birth")]
        public DateOfBirth DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "etag")]
        public string ETag { get; set; }

        [JsonProperty(PropertyName = "kind")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PersonWithSignificantControlKind Kind { get; set; }

        [JsonProperty(PropertyName = "links")]
        public PersonWithSignificantControlLinks Links { get; set; }

        public string PersonWithSignificantControlId
        {
            get
            {
                return Links.PersonWithSignificantControlId;
            }
        }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "name_elements")]
        public NameElements NameElements { get; set; }

        [JsonProperty(PropertyName = "nationality")]
        public string Nationality { get; set; }

        [JsonProperty(PropertyName = "natures_of_control", ItemConverterType = typeof(StringEnumConverter))]
        public PersonWithSignificantControlNatureOfControl[] NaturesOfControl { get; set; }

        [JsonProperty(PropertyName = "notified_on")]
        public DateTime NotifiedOn { get; set; }
    }
}

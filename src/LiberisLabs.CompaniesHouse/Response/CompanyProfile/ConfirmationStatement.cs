using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LiberisLabs.CompaniesHouse.Response.CompanyProfile
{
    public class ConfirmationStatement
    {
        [JsonProperty(PropertyName = "last_made_up_to")]
        public DateTime? LastMadeUpTo { get; set; }

        [JsonProperty(PropertyName = "next_due")]
        public DateTime? NextDue { get; set; }

        [JsonProperty(PropertyName = "next_made_up_to")]
        public DateTime? NextMadeUpTo { get; set; }

        [JsonProperty(PropertyName = "overdue")]
        public bool? Overdue { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class ConfirmationStatement
    {
        [JsonPropertyName("last_made_up_to")]
        public DateTime? LastMadeUpTo { get; set; }

        [JsonPropertyName("next_due")]
        public DateTime? NextDue { get; set; }

        [JsonPropertyName("next_made_up_to")]
        public DateTime? NextMadeUpTo { get; set; }

        [JsonPropertyName("overdue")]
        public bool? Overdue { get; set; }
    }
}

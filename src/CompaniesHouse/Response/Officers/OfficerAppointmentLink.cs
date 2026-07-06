using System;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Officers
{
    public class OfficerAppointmentLink
    {
        [JsonPropertyName("appointments")]
        public string? AppointmentsResource { get; set; }

        [JsonIgnore]
        public string? OfficerId
        {
            get
            {
                if (string.IsNullOrWhiteSpace(AppointmentsResource))
                {
                    return null;
                }

                const string prefix = "/officers/";
                const string suffix = "/appointments";

                var officerStart = AppointmentsResource.IndexOf(prefix, StringComparison.Ordinal);
                if (officerStart < 0)
                {
                    return null;
                }

                officerStart += prefix.Length;

                var officerEnd = AppointmentsResource.IndexOf(suffix, officerStart, StringComparison.Ordinal);
                if (officerEnd <= officerStart)
                {
                    return null;
                }

                return AppointmentsResource.Substring(officerStart, officerEnd - officerStart);
            }
        }
    }
}

using System;

namespace CompaniesHouse.UriBuilders
{
    public class OfficersAppointmentUriBuilder : IOfficersAppointmentUriBuilder
    {
        public Uri Build(string companyNumber, string appointmentId)
        {
            var path = $"company/{Uri.EscapeDataString(companyNumber)}/appointments/{appointmentId}";

            return new Uri(path, UriKind.Relative);
        }
    }
}
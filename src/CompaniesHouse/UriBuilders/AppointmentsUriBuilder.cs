using System;

namespace CompaniesHouse.UriBuilders
{
    public class AppointmentsUriBuilder : IAppointmentsUriBuilder
    {
        public Uri Build(string officerId, int startIndex, int pageSize)
        {
            var path = $"officers/{Uri.EscapeDataString(officerId)}/appointments?items_per_page={pageSize}&start_index={startIndex}";

            return new Uri(path, UriKind.Relative);
        }
    }
}

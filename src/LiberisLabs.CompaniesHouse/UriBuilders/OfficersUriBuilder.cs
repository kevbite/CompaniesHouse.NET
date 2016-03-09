using System;

namespace LiberisLabs.CompaniesHouse.UriBuilders
{
    public class OfficersUriBuilder : IOfficersUriBuilder
    {
        public Uri Build(string companyNumber, int startIndex, int pageSize)
        {
            var path = $"company/{Uri.EscapeDataString(companyNumber)}/officers?items_per_page={pageSize}&start_index={startIndex}";

            return new Uri(path, UriKind.Relative);
        }
    }
}

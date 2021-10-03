using System;

namespace CompaniesHouse.UriBuilders
{
    public class ChargesUriBuilder : IChargesUriBuilder
    {
        public Uri Build(string companyNumber, int startIndex, int pageSize)
        {
            var path = $"company/{Uri.EscapeDataString(companyNumber)}/charges?items_per_page={pageSize}&start_index={startIndex}";

            return new Uri(path, UriKind.Relative);
        }
        
        public Uri Build(string companyNumber, string chargeId)
        {
            var path = $"company/{Uri.EscapeDataString(companyNumber)}/charges/{chargeId}";

            return new Uri(path, UriKind.Relative);
        }
    }
}
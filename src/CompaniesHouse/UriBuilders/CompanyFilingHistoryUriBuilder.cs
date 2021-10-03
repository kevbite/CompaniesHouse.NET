using System;

namespace CompaniesHouse.UriBuilders
{
    public class CompanyFilingHistoryUriBuilder : ICompanyFilingHistoryUriBuilder
    {
        public Uri Build(string companyNumber, int startIndex, int pageSize)
        {
            var path = $"company/{Uri.EscapeDataString(companyNumber)}/filing-history?items_per_page={pageSize}&start_index={startIndex}";

            return new Uri(path, UriKind.Relative);
        }

        public Uri Build(string companyNumber, string transactionId)
        {
            var path = $"company/{Uri.EscapeDataString(companyNumber)}/filing-history/{transactionId}";

            return new Uri(path, UriKind.Relative);
        }
    }
}

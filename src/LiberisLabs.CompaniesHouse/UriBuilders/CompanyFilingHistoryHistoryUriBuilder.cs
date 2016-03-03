using System;

namespace LiberisLabs.CompaniesHouse.UriBuilders
{
    public class CompanyFilingHistoryUriBuilder : ICompanyFilingHistoryUriBuilder
    {
        public Uri Build(string companyNumber, int startIndex, int pageSize)
        {
            var path = string.Format("company/{0}/filing-history?items_per_page={1}&start_index={2}", Uri.EscapeDataString(companyNumber), pageSize, startIndex);

            return new Uri(path, UriKind.Relative);
        }
    }
}

using System;

namespace LiberisLabs.CompaniesHouse.UriBuilders
{
    public class CompanyFilingUriBuilder : ICompanyFilingUriBuilder
    {
        public Uri Build(string companyNumber, int pageSize = 25, int startIndex = 0)
        {
            var path = string.Format("company/{0}/filing-history?items_per_page={1}&start_index={2}", Uri.EscapeDataString(companyNumber), pageSize, startIndex);

            return new Uri(path, UriKind.Relative);
        }
    }
}

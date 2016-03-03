using System;

namespace LiberisLabs.CompaniesHouse.UriBuilders
{
    public class CompanyFilingUriBuilder : ICompanyFilingUriBuilder
    {
        public Uri Build(string companyNumber)
        {
            var path = string.Format("company/{0}/filing-history", Uri.EscapeDataString(companyNumber));

            return new Uri(path, UriKind.Relative);
        }
    }
}

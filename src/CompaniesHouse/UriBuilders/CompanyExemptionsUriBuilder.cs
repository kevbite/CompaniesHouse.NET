using System;

namespace CompaniesHouse.UriBuilders
{
    public class CompanyExemptionsUriBuilder : ICompanyExemptionsUriBuilder
    {
        public Uri Build(string companyNumber)
        {
            var path = $"company/{Uri.EscapeDataString(companyNumber)}/exemptions";
            return new Uri(path, UriKind.Relative);
        }
    }
}

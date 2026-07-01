using System;

namespace CompaniesHouse.UriBuilders
{
    public class CompanyInsolvencyInformationUriBuilder : ICompanyInsolvencyInformationUriBuilder
    {
        public Uri Build(string companyNumber)
        {
            var path = $"company/{Uri.EscapeDataString(companyNumber)}/insolvency";

            return new Uri(path, UriKind.Relative);
        }
    }
}

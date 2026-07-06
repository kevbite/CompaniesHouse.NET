using System;

namespace CompaniesHouse.UriBuilders
{
    public class CompanyRegistersUriBuilder : ICompanyRegistersUriBuilder
    {
        public Uri Build(string companyNumber)
        {
            var path = $"company/{Uri.EscapeDataString(companyNumber)}/registers";
            return new Uri(path, UriKind.Relative);
        }
    }
}

using System;

namespace CompaniesHouse.UriBuilders
{
    public class CompanyUkEstablishmentsUriBuilder : ICompanyUkEstablishmentsUriBuilder
    {
        public Uri Build(string companyNumber)
        {
            var path = $"company/{Uri.EscapeDataString(companyNumber)}/uk-establishments";
            return new Uri(path, UriKind.Relative);
        }
    }
}

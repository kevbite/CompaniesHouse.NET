using System;

namespace CompaniesHouse.UriBuilders
{
    public interface ICompanyExemptionsUriBuilder
    {
        Uri Build(string companyNumber);
    }
}

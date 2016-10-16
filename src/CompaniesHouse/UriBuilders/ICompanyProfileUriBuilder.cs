using System;

namespace CompaniesHouse.UriBuilders
{
    public interface ICompanyProfileUriBuilder
    {
        Uri Build(string companyNumber);
    }
}
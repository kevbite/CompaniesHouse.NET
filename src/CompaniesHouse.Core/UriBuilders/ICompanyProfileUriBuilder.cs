using System;

namespace CompaniesHouse.Core.UriBuilders
{
    public interface ICompanyProfileUriBuilder
    {
        Uri Build(string companyNumber);
    }
}
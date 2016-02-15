using System;

namespace LiberisLabs.CompaniesHouse.UriBuilders
{
    public interface ICompanyProfileUriBuilder
    {
        Uri Build(string companyNumber);
    }
}
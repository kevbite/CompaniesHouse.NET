using System;

namespace LiberisLabs.CompaniesHouse.UriBuilders
{
    public interface ICompanyFilingUriBuilder
    {
        Uri Build(string companyNumber);
    }
}
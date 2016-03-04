using System;

namespace LiberisLabs.CompaniesHouse.UriBuilders
{
    public interface ICompanyFilingHistoryUriBuilder
    {
        Uri Build(string companyNumber, int startIndex, int pageSize);
    }
}
using System;

namespace CompaniesHouse.Core.UriBuilders
{
    public interface ICompanyFilingHistoryUriBuilder
    {
        Uri Build(string companyNumber, int startIndex, int pageSize);
    }
}
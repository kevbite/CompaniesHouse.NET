using System;

namespace CompaniesHouse.UriBuilders
{
    public interface ICompanyFilingHistoryUriBuilder
    {
        Uri Build(string companyNumber, int startIndex, int pageSize);
        Uri Build(string companyNumber, string transactionId);
    }
}
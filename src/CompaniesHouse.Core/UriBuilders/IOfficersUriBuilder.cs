using System;

namespace CompaniesHouse.Core.UriBuilders
{
    public interface IOfficersUriBuilder
    {
        Uri Build(string companyNumber, int startIndex, int pageSize);
    }
}
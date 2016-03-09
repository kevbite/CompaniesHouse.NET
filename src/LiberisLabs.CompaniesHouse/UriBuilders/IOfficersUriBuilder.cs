using System;

namespace LiberisLabs.CompaniesHouse.UriBuilders
{
    public interface IOfficersUriBuilder
    {
        Uri Build(string companyNumber, int startIndex, int pageSize);
    }
}
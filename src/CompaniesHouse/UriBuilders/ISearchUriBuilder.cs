using System;
using CompaniesHouse.Request;

namespace CompaniesHouse.UriBuilders
{
    public interface ISearchUriBuilder
    {
        Uri Build(SearchRequest request);
    }
}
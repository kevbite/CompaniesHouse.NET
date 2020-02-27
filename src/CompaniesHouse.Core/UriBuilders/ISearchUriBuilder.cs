using System;
using CompaniesHouse.Core.Request;

namespace CompaniesHouse.Core.UriBuilders
{
    public interface ISearchUriBuilder
    {
        Uri Build(SearchRequest request);
    }
}
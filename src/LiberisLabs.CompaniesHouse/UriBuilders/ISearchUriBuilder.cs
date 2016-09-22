using System;
using LiberisLabs.CompaniesHouse.Request;

namespace LiberisLabs.CompaniesHouse.UriBuilders
{
    public interface ISearchUriBuilder
    {
        Uri Build(SearchRequest request);
    }
}
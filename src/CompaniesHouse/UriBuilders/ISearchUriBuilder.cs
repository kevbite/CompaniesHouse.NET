using System;
using CompaniesHouse.Request;

namespace CompaniesHouse.UriBuilders
{
    public interface ISearchUriBuilder<in TSearch> where TSearch : ISearchRequest
    {
        Uri Build(TSearch request);
    }
}
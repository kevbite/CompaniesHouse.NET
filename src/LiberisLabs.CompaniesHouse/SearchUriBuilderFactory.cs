using System;
using System.Collections.Generic;
using LiberisLabs.CompaniesHouse.Response.CompanySearch;
using LiberisLabs.CompaniesHouse.UriBuilders;

namespace LiberisLabs.CompaniesHouse
{
    public class SearchUriBuilderFactory : ISearchUriBuilderFactory
    {
        public ISearchUriBuilder Create<TSearch>()
        {
            var type = typeof(TSearch);

            return _map[type]();
        }

        private readonly IDictionary<Type, Func<ISearchUriBuilder>> _map = new Dictionary
            <Type, Func<ISearchUriBuilder>>()
            {
                {typeof(CompanySearch), () => new SearchUriBuilder("search/companies")}
            };
    }
}
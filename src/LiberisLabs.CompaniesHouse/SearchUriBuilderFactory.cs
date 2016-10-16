using System;
using System.Collections.Generic;
using LiberisLabs.CompaniesHouse.Response.Search.AllSearch;
using LiberisLabs.CompaniesHouse.Response.Search.CompanySearch;
using LiberisLabs.CompaniesHouse.Response.Search.DisqualifiedOfficersSearch;
using LiberisLabs.CompaniesHouse.Response.Search.OfficerSearch;
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
                {typeof(CompanySearch), () => new SearchUriBuilder("search/companies")},
                {typeof(OfficerSearch), () => new SearchUriBuilder("search/officers")},
                {typeof(DisqualifiedOfficerSearch), () => new SearchUriBuilder("search/disqualified-officers")},
                {typeof(AllSearch), () => new SearchUriBuilder("search")}
            };
    }
}
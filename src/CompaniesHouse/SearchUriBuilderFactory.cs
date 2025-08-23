using CompaniesHouse.Request;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    public class SearchUriBuilderFactory : ISearchUriBuilderFactory
    {
        public ISearchUriBuilder<TSearch> Create<TSearch, TReturn>() where TSearch : SearchRequest<TReturn>
        {
            var type = typeof(TSearch);

            if (type == typeof(SearchCompanyRequest))
            {
                return (ISearchUriBuilder<TSearch>)new SearchCompanyUriBuilder("search/companies");
            }

            if (type == typeof(SearchOfficerRequest))
            {
                return (ISearchUriBuilder<TSearch>)new QuerySearchUriBuilder<SearchOfficerRequest>("search/officers");
            }

            if (type == typeof(SearchDisqualifiedOfficerRequest))
            {
                return (ISearchUriBuilder<TSearch>)new QuerySearchUriBuilder<SearchDisqualifiedOfficerRequest>(
                    "search/disqualified-officers");
            }

            if (type == typeof(SearchAllRequest))
            {
                return (ISearchUriBuilder<TSearch>)new QuerySearchUriBuilder<SearchAllRequest>("search");
            }

            if (type == typeof(AdvancedSearchCompanyRequest))
            {
                return (ISearchUriBuilder<TSearch>)new AdvancedSearchCompanyUriBuilder("advanced-search/companies");
            }

            throw new InvalidOperationException();
        }
    }
}
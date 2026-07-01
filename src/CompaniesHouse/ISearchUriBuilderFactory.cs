using CompaniesHouse.Request;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    public interface ISearchUriBuilderFactory
    {
        ISearchUriBuilder<TSearch> Create<TSearch, TReturn>();
    }
}
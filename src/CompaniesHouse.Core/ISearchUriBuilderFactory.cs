using CompaniesHouse.Core.UriBuilders;

namespace CompaniesHouse.Core
{
    public interface ISearchUriBuilderFactory
    {
        ISearchUriBuilder Create<TSearch>();
    }
}
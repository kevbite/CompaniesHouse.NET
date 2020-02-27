using CompaniesHouse.UriBuilders;

namespace CompaniesHouse
{
    public interface ISearchUriBuilderFactory
    {
        ISearchUriBuilder Create<TSearch>();
    }
}
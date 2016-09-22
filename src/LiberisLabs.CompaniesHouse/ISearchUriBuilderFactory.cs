using LiberisLabs.CompaniesHouse.UriBuilders;

namespace LiberisLabs.CompaniesHouse
{
    public interface ISearchUriBuilderFactory
    {
        ISearchUriBuilder Create<TSearch>();
    }
}
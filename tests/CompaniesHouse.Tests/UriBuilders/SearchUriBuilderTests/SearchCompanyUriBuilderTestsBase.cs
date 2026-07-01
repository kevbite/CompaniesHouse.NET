using System;
using CompaniesHouse.Request;
using CompaniesHouse.UriBuilders;

namespace CompaniesHouse.Tests.UriBuilders.SearchUriBuilderTests
{
    public abstract partial class SearchCompanyUriBuilderTestsBase
    {
        private readonly SearchCompanyUriBuilder _uriBuilder;
        private readonly Uri _baseUri = new Uri("https://example.test/");
        private readonly string _path = "search/companies";

        protected SearchCompanyUriBuilderTestsBase()
        {
            _uriBuilder = new SearchCompanyUriBuilder(_path);
        }

        protected virtual string? Restrictions => null;

        private Uri ActualUri => _uriBuilder.Build(new SearchCompanyRequest
        {
            Query = "company name",
            Restrictions = Restrictions,
        });

        public Thens Then => new Thens(this);
    }
}

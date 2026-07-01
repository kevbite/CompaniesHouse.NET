using System;
using CompaniesHouse.Request;
using CompaniesHouse.UriBuilders;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.SearchUriBuilderTests
{
    public class SearchDissolvedCompaniesUriBuilderTests
    {
        [Fact]
        public void Build_IncludesConfiguredParameters()
        {
            var sut = new SearchDissolvedCompaniesUriBuilder("dissolved-search/companies");

            var uri = sut.Build(new SearchDissolvedCompaniesRequest
            {
                Query = "abc & co",
                SearchType = "previous-name-dissolved",
                SearchAbove = "A/1",
                SearchBelow = "B/2",
                Size = 25,
                StartIndex = 30,
            });

            uri.ToString().ShouldBe("dissolved-search/companies?q=abc%20%26%20co&search_type=previous-name-dissolved&search_above=A%2F1&search_below=B%2F2&size=25&start_index=30");
        }

        [Fact]
        public void Build_OmitsOptionalParametersWhenTheyAreNotSupplied()
        {
            var sut = new SearchDissolvedCompaniesUriBuilder("dissolved-search/companies");

            var uri = sut.Build(new SearchDissolvedCompaniesRequest
            {
                Query = "abc",
                SearchType = "best-match",
            });

            uri.ShouldBe(new Uri("dissolved-search/companies?q=abc&search_type=best-match", UriKind.Relative));
        }
    }
}

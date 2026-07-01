using System;
using CompaniesHouse.Request;
using CompaniesHouse.UriBuilders;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.SearchUriBuilderTests
{
    public class SearchCompaniesAlphabeticallyUriBuilderTests
    {
        [Fact]
        public void Build_IncludesConfiguredParameters()
        {
            var sut = new SearchCompaniesAlphabeticallyUriBuilder("alphabetical-search/companies");

            var uri = sut.Build(new SearchCompaniesAlphabeticallyRequest
            {
                Query = "abc & co",
                SearchAbove = "A/1",
                SearchBelow = "B/2",
                Size = 25,
            });

            uri.ToString().ShouldBe("alphabetical-search/companies?q=abc%20%26%20co&search_above=A%2F1&search_below=B%2F2&size=25");
        }

        [Fact]
        public void Build_OmitsOptionalParametersWhenTheyAreNotSupplied()
        {
            var sut = new SearchCompaniesAlphabeticallyUriBuilder("alphabetical-search/companies");

            var uri = sut.Build(new SearchCompaniesAlphabeticallyRequest
            {
                Query = "abc",
            });

            uri.ShouldBe(new Uri("alphabetical-search/companies?q=abc", UriKind.Relative));
        }
    }
}

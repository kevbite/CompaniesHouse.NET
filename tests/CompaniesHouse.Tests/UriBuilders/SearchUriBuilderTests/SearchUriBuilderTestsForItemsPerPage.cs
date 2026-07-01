using System;
using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.SearchUriBuilderTests
{
    public class SearchUriBuilderTestsForItemsPerPage : SearchUriBuilderTestsBase
    {
        protected override int? ItemsPerPage { get; } = new Random().Next();

        [Fact]
        public void ThenTheUriQueryStringContainsTheQuery() => Then.TheUriQueryStringContainsTheQuery();

        [Fact]
        public void ThenTheUriQueryStringContainsTheItemsPerPage() => Then.TheUriQueryStringContainsTheItemsPerPage();

        [Fact]
        public void ThenTheUriQueryStringDoesNotContainsTheStartIndex() => Then.TheUriQueryStringDoesNotContainsTheStartIndex();
    }
}
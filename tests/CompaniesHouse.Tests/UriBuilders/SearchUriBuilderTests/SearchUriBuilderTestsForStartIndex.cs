using System;
using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.SearchUriBuilderTests
{
    public class SearchUriBuilderTestsForStartIndex : SearchUriBuilderTestsBase
    {
        protected override int? StartIndex { get; } = new Random().Next();

        [Fact]
        public void ThenTheUriQueryStringContainsTheQuery() => Then.TheUriQueryStringContainsTheQuery();

        [Fact]
        public void ThenTheUriQueryStringDoesNotContainsTheItemsPerPage() => Then.TheUriQueryStringDoesNotContainsTheItemsPerPage();

        [Fact]
        public void ThenTheUriQueryStringContainsTheStartIndex() => Then.TheUriQueryStringContainsTheStartIndex();

    }
}
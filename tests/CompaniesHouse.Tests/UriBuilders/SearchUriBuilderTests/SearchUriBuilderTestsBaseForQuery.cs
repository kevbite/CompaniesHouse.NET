using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.SearchUriBuilderTests
{
    public class SearchUriBuilderTestsBaseForQuery : SearchUriBuilderTestsBase
    {
        [Fact]
        public void ThenTheUriQueryStringContainsTheQuery() => Then.TheUriQueryStringContainsTheQuery();

        [Fact]
        public void ThenTheUriQueryStringDoesNotContainsTheItemsPerPage() => Then.TheUriQueryStringDoesNotContainsTheItemsPerPage();

        [Fact]
        public void ThenTheUriQueryStringDoesNotContainsTheStartIndex() => Then.TheUriQueryStringDoesNotContainsTheStartIndex();

    }
}
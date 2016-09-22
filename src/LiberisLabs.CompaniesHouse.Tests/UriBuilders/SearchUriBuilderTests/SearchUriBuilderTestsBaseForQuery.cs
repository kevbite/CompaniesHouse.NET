using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.Tests.UriBuilders.SearchUriBuilderTests
{
    [TestFixture]
    public class SearchUriBuilderTestsBaseForQuery : SearchUriBuilderTestsBase
    {
        [Test]
        public void ThenTheUriQueryStringContainsTheQuery() => Then.TheUriQueryStringContainsTheQuery();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheItemsPerPage() => Then.TheUriQueryStringDoesNotContainsTheItemsPerPage();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheStartIndex() => Then.TheUriQueryStringDoesNotContainsTheStartIndex();

    }
}
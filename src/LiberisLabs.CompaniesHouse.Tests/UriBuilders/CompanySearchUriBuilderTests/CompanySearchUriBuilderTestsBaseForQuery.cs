using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.Tests.UriBuilders.CompanySearchUriBuilderTests
{
    [TestFixture]
    public class CompanySearchUriBuilderTestsBaseForQuery : CompanySearchUriBuilderTestsBase
    {
        [Test]
        public void ThenTheUriQueryStringContainsTheQuery() => Then.TheUriQueryStringContainsTheQuery();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheItemsPerPage() => Then.TheUriQueryStringDoesNotContainsTheItemsPerPage();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheStartIndex() => Then.TheUriQueryStringDoesNotContainsTheStartIndex();

    }
}
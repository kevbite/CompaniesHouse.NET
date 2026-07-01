using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.SearchUriBuilderTests
{
    public class SearchCompanyUriBuilderTestsForRestrictionsWhenEmpty : SearchCompanyUriBuilderTestsBase
    {
        protected override string? Restrictions => string.Empty;

        [Fact]
        public void ThenTheUriQueryStringDoesNotContainRestrictions() => Then.TheUriQueryStringDoesNotContainRestrictions();
    }
}

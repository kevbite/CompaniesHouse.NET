using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.SearchUriBuilderTests
{
    public class SearchCompanyUriBuilderTestsForRestrictionsWhenNull : SearchCompanyUriBuilderTestsBase
    {
        [Fact]
        public void ThenTheUriQueryStringDoesNotContainRestrictions() => Then.TheUriQueryStringDoesNotContainRestrictions();
    }
}

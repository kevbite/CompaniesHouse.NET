using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.SearchUriBuilderTests
{
    public class SearchCompanyUriBuilderTestsForRestrictionsWhenWhitespace : SearchCompanyUriBuilderTestsBase
    {
        protected override string? Restrictions => "   ";

        [Fact]
        public void ThenTheUriQueryStringDoesNotContainRestrictions() => Then.TheUriQueryStringDoesNotContainRestrictions();
    }
}

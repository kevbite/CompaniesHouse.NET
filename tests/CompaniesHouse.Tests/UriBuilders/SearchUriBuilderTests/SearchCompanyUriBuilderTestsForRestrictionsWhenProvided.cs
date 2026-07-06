using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.SearchUriBuilderTests
{
    public class SearchCompanyUriBuilderTestsForRestrictionsWhenProvided : SearchCompanyUriBuilderTestsBase
    {
        protected override string? Restrictions => "active companies & subsidiaries";

        [Fact]
        public void ThenTheUriQueryStringContainsRestrictions() => Then.TheUriQueryStringContainsRestrictions();
    }
}

using NUnit.Framework;

namespace CompaniesHouse.Tests.UriBuilders.AdvancedSearchCompanyUriBuilderTests
{
    [TestFixture]
    public class AdvancedSearchCompanyUriBuilderTestsForQuery : AdvancedSearchCompanyUriBuilderTestsBase
    {

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheItemsPerPage() => Then.TheUriQueryStringDoesNotContainsTheItemsPerPage();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheStartIndex() => Then.TheUriQueryStringDoesNotContainsTheStartIndex();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheCompanyNameIncludes() => Then.TheUriQueryStringDoesNotContainsTheCompanyNameIncludes();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheCompanyNameExcludes() => Then.TheUriQueryStringDoesNotContainsTheCompanyNameExcludes();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheCompanyStatus() => Then.TheUriQueryStringDoesNotContainsTheCompanyStatus();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheCompanySubtype() => Then.TheUriQueryStringDoesNotContainsTheCompanySubtype();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheCompanyType() => Then.TheUriQueryStringDoesNotContainsTheCompanyType();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheDissolvedFrom() => Then.TheUriQueryStringDoesNotContainsTheDissolvedFrom();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheDissolvedTo() => Then.TheUriQueryStringDoesNotContainsTheDissolvedTo();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheIncorporatedFrom() => Then.TheUriQueryStringDoesNotContainsTheIncorporatedFrom();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheIncorporatedTo() => Then.TheUriQueryStringDoesNotContainsTheIncorporatedTo();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheLocation() => Then.TheUriQueryStringDoesNotContainsTheLocation();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheSicCodes() => Then.TheUriQueryStringDoesNotContainsTheSicCodes();
    }
}

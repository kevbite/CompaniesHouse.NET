using System.Collections.Generic;
using NUnit.Framework;

namespace CompaniesHouse.Tests.UriBuilders.AdvancedSearchCompanyUriBuilderTests
{
    [TestFixture]
    public class AdvancedSearchCompanyUriBuilderTestsForSicCodes : AdvancedSearchCompanyUriBuilderTestsBase
    {
        protected override IReadOnlyCollection<string> SicCodes { get; } = new[] { "62012", "62020", "70221" };


        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheLocation() => Then.TheUriQueryStringDoesNotContainsTheLocation();

        [Test]
        public void ThenTheUriQueryStringContainsTheSicCodes() => Then.TheUriQueryStringContainsTheSicCodes();
    }
}

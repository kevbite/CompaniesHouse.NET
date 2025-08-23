using System;
using NUnit.Framework;

namespace CompaniesHouse.Tests.UriBuilders.AdvancedSearchCompanyUriBuilderTests
{
    [TestFixture]
    public class AdvancedSearchCompanyUriBuilderTestsForLocation : AdvancedSearchCompanyUriBuilderTestsBase
    {
        protected override string Location { get; } = "London";


        [Test]
        public void ThenTheUriQueryStringContainsTheLocation() => Then.TheUriQueryStringContainsTheLocation();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheSicCodes() => Then.TheUriQueryStringDoesNotContainsTheSicCodes();
    }
}

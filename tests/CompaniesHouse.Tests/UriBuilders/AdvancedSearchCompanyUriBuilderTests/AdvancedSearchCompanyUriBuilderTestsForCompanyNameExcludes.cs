using System;
using NUnit.Framework;

namespace CompaniesHouse.Tests.UriBuilders.AdvancedSearchCompanyUriBuilderTests
{
    [TestFixture]
    public class AdvancedSearchCompanyUriBuilderTestsForCompanyNameExcludes : AdvancedSearchCompanyUriBuilderTestsBase
    {
        protected override string CompanyNameExcludes { get; } = Guid.NewGuid().ToString();


        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheCompanyNameIncludes() => Then.TheUriQueryStringDoesNotContainsTheCompanyNameIncludes();

        [Test]
        public void ThenTheUriQueryStringContainsTheCompanyNameExcludes() => Then.TheUriQueryStringContainsTheCompanyNameExcludes();
    }
}

using System;
using NUnit.Framework;

namespace CompaniesHouse.Tests.UriBuilders.AdvancedSearchCompanyUriBuilderTests
{
    [TestFixture]
    public class AdvancedSearchCompanyUriBuilderTestsForCompanyNameIncludes : AdvancedSearchCompanyUriBuilderTestsBase
    {
        protected override string CompanyNameIncludes { get; } = Guid.NewGuid().ToString();


        [Test]
        public void ThenTheUriQueryStringContainsTheCompanyNameIncludes() => Then.TheUriQueryStringContainsTheCompanyNameIncludes();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheCompanyNameExcludes() => Then.TheUriQueryStringDoesNotContainsTheCompanyNameExcludes();
    }
}

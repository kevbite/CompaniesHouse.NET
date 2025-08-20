using System.Collections.Generic;
using CompaniesHouse.Response;
using NUnit.Framework;

namespace CompaniesHouse.Tests.UriBuilders.AdvancedSearchCompanyUriBuilderTests
{
    [TestFixture]
    public class AdvancedSearchCompanyUriBuilderTestsForCompanyType : AdvancedSearchCompanyUriBuilderTestsBase
    {
        protected override IReadOnlyCollection<CompanyType> CompanyType { get; } = new[] { Response.CompanyType.Ltd };


        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheCompanyStatus() => Then.TheUriQueryStringDoesNotContainsTheCompanyStatus();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheCompanySubtype() => Then.TheUriQueryStringDoesNotContainsTheCompanySubtype();

        [Test]
        public void ThenTheUriQueryStringContainsTheCompanyType() => Then.TheUriQueryStringContainsTheCompanyType();
    }
}

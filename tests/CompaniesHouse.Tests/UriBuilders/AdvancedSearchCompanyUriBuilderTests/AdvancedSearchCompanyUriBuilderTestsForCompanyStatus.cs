using System.Collections.Generic;
using CompaniesHouse.Response;
using NUnit.Framework;

namespace CompaniesHouse.Tests.UriBuilders.AdvancedSearchCompanyUriBuilderTests
{
    [TestFixture]
    public class AdvancedSearchCompanyUriBuilderTestsForCompanyStatus : AdvancedSearchCompanyUriBuilderTestsBase
    {
        protected override IReadOnlyCollection<CompanyStatus> CompanyStatus { get; } = new[] { Response.CompanyStatus.Active, Response.CompanyStatus.Dissolved };
        
        [Test]
        public void ThenTheUriQueryStringContainsTheCompanyStatus() => Then.TheUriQueryStringContainsTheCompanyStatus();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheCompanySubtype() => Then.TheUriQueryStringDoesNotContainsTheCompanySubtype();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheCompanyType() => Then.TheUriQueryStringDoesNotContainsTheCompanyType();
    }
}

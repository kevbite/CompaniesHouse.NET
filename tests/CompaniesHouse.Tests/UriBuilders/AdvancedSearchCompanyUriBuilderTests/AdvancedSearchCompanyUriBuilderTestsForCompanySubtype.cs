using System.Collections.Generic;
using CompaniesHouse.Response;
using NUnit.Framework;

namespace CompaniesHouse.Tests.UriBuilders.AdvancedSearchCompanyUriBuilderTests
{
    [TestFixture]
    public class AdvancedSearchCompanyUriBuilderTestsForCompanySubtype : AdvancedSearchCompanyUriBuilderTestsBase
    {
        protected override IReadOnlyCollection<CompanySubType> CompanySubtype { get; } = new[] { Response.CompanySubType.CommunityInterestCompany };


        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheCompanyStatus() => Then.TheUriQueryStringDoesNotContainsTheCompanyStatus();

        [Test]
        public void ThenTheUriQueryStringContainsTheCompanySubtype() => Then.TheUriQueryStringContainsTheCompanySubtype();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheCompanyType() => Then.TheUriQueryStringDoesNotContainsTheCompanyType();
    }
}

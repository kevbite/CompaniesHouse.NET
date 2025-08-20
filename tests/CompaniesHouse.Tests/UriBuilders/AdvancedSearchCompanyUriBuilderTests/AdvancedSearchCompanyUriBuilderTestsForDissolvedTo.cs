using System;
using NUnit.Framework;

namespace CompaniesHouse.Tests.UriBuilders.AdvancedSearchCompanyUriBuilderTests
{
    [TestFixture]
    public class AdvancedSearchCompanyUriBuilderTestsForDissolvedTo : AdvancedSearchCompanyUriBuilderTestsBase
    {
        protected override DateTime? DissolvedTo { get; } = new DateTime(2023, 12, 31);


        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheDissolvedFrom() => Then.TheUriQueryStringDoesNotContainsTheDissolvedFrom();

        [Test]
        public void ThenTheUriQueryStringContainsTheDissolvedTo() => Then.TheUriQueryStringContainsTheDissolvedTo();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheIncorporatedFrom() => Then.TheUriQueryStringDoesNotContainsTheIncorporatedFrom();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheIncorporatedTo() => Then.TheUriQueryStringDoesNotContainsTheIncorporatedTo();
    }
}

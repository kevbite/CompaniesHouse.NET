using System;
using NUnit.Framework;

namespace CompaniesHouse.Tests.UriBuilders.AdvancedSearchCompanyUriBuilderTests
{
    [TestFixture]
    public class AdvancedSearchCompanyUriBuilderTestsForDissolvedFrom : AdvancedSearchCompanyUriBuilderTestsBase
    {
        protected override DateTime? DissolvedFrom { get; } = new DateTime(2020, 1, 1);


        [Test]
        public void ThenTheUriQueryStringContainsTheDissolvedFrom() => Then.TheUriQueryStringContainsTheDissolvedFrom();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheDissolvedTo() => Then.TheUriQueryStringDoesNotContainsTheDissolvedTo();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheIncorporatedFrom() => Then.TheUriQueryStringDoesNotContainsTheIncorporatedFrom();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheIncorporatedTo() => Then.TheUriQueryStringDoesNotContainsTheIncorporatedTo();
    }
}

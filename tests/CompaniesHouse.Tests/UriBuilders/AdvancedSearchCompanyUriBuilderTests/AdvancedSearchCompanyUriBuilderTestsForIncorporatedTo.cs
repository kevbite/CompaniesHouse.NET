using System;
using NUnit.Framework;

namespace CompaniesHouse.Tests.UriBuilders.AdvancedSearchCompanyUriBuilderTests
{
    [TestFixture]
    public class AdvancedSearchCompanyUriBuilderTestsForIncorporatedTo : AdvancedSearchCompanyUriBuilderTestsBase
    {
        protected override DateTime? IncorporatedTo { get; } = new DateTime(2022, 12, 31);


        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheDissolvedFrom() => Then.TheUriQueryStringDoesNotContainsTheDissolvedFrom();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheDissolvedTo() => Then.TheUriQueryStringDoesNotContainsTheDissolvedTo();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheIncorporatedFrom() => Then.TheUriQueryStringDoesNotContainsTheIncorporatedFrom();

        [Test]
        public void ThenTheUriQueryStringContainsTheIncorporatedTo() => Then.TheUriQueryStringContainsTheIncorporatedTo();
    }
}

using System;
using NUnit.Framework;

namespace CompaniesHouse.Tests.UriBuilders.AdvancedSearchCompanyUriBuilderTests
{
    [TestFixture]
    public class AdvancedSearchCompanyUriBuilderTestsForIncorporatedFrom : AdvancedSearchCompanyUriBuilderTestsBase
    {
        protected override DateTime? IncorporatedFrom { get; } = new DateTime(2015, 1, 1);


        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheDissolvedFrom() => Then.TheUriQueryStringDoesNotContainsTheDissolvedFrom();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheDissolvedTo() => Then.TheUriQueryStringDoesNotContainsTheDissolvedTo();

        [Test]
        public void ThenTheUriQueryStringContainsTheIncorporatedFrom() => Then.TheUriQueryStringContainsTheIncorporatedFrom();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheIncorporatedTo() => Then.TheUriQueryStringDoesNotContainsTheIncorporatedTo();
    }
}

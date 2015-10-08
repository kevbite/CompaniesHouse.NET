using System;
using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.Tests.UriBuilders.CompanySearchUriBuilderTests
{
    [TestFixture]
    public class CompanySearchUriBuilderTestsForItemsPerPage : CompanySearchUriBuilderTestsBase
    {
        protected override int? ItemsPerPage { get; } = new Random().Next();

        [Test]
        public void ThenTheUriQueryStringContainsTheQuery() => Then.TheUriQueryStringContainsTheQuery();

        [Test]
        public void ThenTheUriQueryStringContainsTheItemsPerPage() => Then.TheUriQueryStringContainsTheItemsPerPage();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheStartIndex() => Then.TheUriQueryStringDoesNotContainsTheStartIndex();
    }
}
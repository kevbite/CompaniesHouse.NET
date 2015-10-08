using System;
using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.Tests.UriBuilders.CompanySearchUriBuilderTests
{
    [TestFixture]
    public class CompanySearchUriBuilderTestsForStartIndex : CompanySearchUriBuilderTestsBase
    {
        protected override int? StartIndex { get; } = new Random().Next();

        [Test]
        public void ThenTheUriQueryStringContainsTheQuery() => Then.TheUriQueryStringContainsTheQuery();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheItemsPerPage() => Then.TheUriQueryStringDoesNotContainsTheItemsPerPage();

        [Test]
        public void ThenTheUriQueryStringContainsTheStartIndex() => Then.TheUriQueryStringContainsTheStartIndex();

    }
}
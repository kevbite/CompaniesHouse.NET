using System;
using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.Tests.UriBuilders.SearchUriBuilderTests
{
    [TestFixture]
    public class SearchUriBuilderTestsForStartIndex : SearchUriBuilderTestsBase
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
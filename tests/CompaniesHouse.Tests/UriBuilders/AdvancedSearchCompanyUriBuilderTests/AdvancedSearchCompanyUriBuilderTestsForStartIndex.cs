using System;
using NUnit.Framework;

namespace CompaniesHouse.Tests.UriBuilders.AdvancedSearchCompanyUriBuilderTests
{
    [TestFixture]
    public class AdvancedSearchCompanyUriBuilderTestsForStartIndex : AdvancedSearchCompanyUriBuilderTestsBase
    {
        protected override int? StartIndex { get; } = new Random().Next();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheItemsPerPage() => Then.TheUriQueryStringDoesNotContainsTheItemsPerPage();

        [Test]
        public void ThenTheUriQueryStringContainsTheStartIndex() => Then.TheUriQueryStringContainsTheStartIndex();
    }
}

using System;
using NUnit.Framework;

namespace CompaniesHouse.Tests.UriBuilders.AdvancedSearchCompanyUriBuilderTests
{
    [TestFixture]
    public class AdvancedSearchCompanyUriBuilderTestsForItemsPerPage : AdvancedSearchCompanyUriBuilderTestsBase
    {
        protected override int? ItemsPerPage { get; } = new Random().Next();


        [Test]
        public void ThenTheUriQueryStringContainsTheItemsPerPage() => Then.TheUriQueryStringContainsTheItemsPerPage();

        [Test]
        public void ThenTheUriQueryStringDoesNotContainsTheStartIndex() => Then.TheUriQueryStringDoesNotContainsTheStartIndex();
    }
}

using System;
using CompaniesHouse.UriBuilders;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.DisqualifiedOfficerUriBuilderTests
{
    public class DisqualifiedOfficerUriBuilderTests
    {
        [Fact]
        public void BuildNatural_EncodesOfficerId()
        {
            var uri = new DisqualifiedOfficerUriBuilder().BuildNatural("abc/123");

            uri.ShouldBe(new Uri("disqualified-officers/natural/abc%2F123", UriKind.Relative));
        }

        [Fact]
        public void BuildCorporate_EncodesOfficerId()
        {
            var uri = new DisqualifiedOfficerUriBuilder().BuildCorporate("abc/123");

            uri.ShouldBe(new Uri("disqualified-officers/corporate/abc%2F123", UriKind.Relative));
        }
    }
}

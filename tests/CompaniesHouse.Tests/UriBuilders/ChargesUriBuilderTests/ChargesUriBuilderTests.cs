using System;
using CompaniesHouse.UriBuilders;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.ChargesUriBuilderTests
{
    public class ChargesUriBuilderTests
    {
        [Fact]
        public void Build_List_EncodesCompanyNumberAndPaging()
        {
            var uri = new ChargesUriBuilder().Build("00/123", 25, 35);

            uri.ShouldBe(new Uri("company/00%2F123/charges?items_per_page=35&start_index=25", UriKind.Relative));
        }

        [Fact]
        public void Build_Single_EncodesCompanyNumber()
        {
            var uri = new ChargesUriBuilder().Build("00/123", "charge-id");

            uri.ShouldBe(new Uri("company/00%2F123/charges/charge-id", UriKind.Relative));
        }
    }
}

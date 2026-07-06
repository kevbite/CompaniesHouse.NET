using System;
using CompaniesHouse.UriBuilders;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.CompanyRegistersUriBuilderTests
{
    public class CompanyRegistersUriBuilderTests
    {
        [Fact]
        public void Build_EncodesCompanyNumber()
        {
            var uri = new CompanyRegistersUriBuilder().Build("00/123");

            uri.ShouldBe(new Uri("company/00%2F123/registers", UriKind.Relative));
        }
    }
}

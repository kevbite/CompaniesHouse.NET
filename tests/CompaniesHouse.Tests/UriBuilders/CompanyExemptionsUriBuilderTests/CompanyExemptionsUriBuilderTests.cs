using System;
using CompaniesHouse.UriBuilders;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.CompanyExemptionsUriBuilderTests
{
    public class CompanyExemptionsUriBuilderTests
    {
        [Fact]
        public void Build_EncodesCompanyNumber()
        {
            var uri = new CompanyExemptionsUriBuilder().Build("00/123");

            uri.ShouldBe(new Uri("company/00%2F123/exemptions", UriKind.Relative));
        }
    }
}

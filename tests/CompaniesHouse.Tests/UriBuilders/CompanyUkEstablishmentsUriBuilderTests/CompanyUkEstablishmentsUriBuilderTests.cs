using System;
using CompaniesHouse.UriBuilders;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.CompanyUkEstablishmentsUriBuilderTests
{
    public class CompanyUkEstablishmentsUriBuilderTests
    {
        [Fact]
        public void Build_EncodesCompanyNumber()
        {
            var uri = new CompanyUkEstablishmentsUriBuilder().Build("FC/040879");

            uri.ShouldBe(new Uri("company/FC%2F040879/uk-establishments", UriKind.Relative));
        }
    }
}

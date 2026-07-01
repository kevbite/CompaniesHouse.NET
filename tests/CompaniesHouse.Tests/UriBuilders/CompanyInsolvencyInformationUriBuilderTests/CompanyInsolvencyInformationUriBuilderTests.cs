using System;
using CompaniesHouse.UriBuilders;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.CompanyInsolvencyInformationUriBuilderTests
{
    public class CompanyInsolvencyInformationUriBuilderTests
    {
        [Fact]
        public void Build_EncodesCompanyNumber()
        {
            var uri = new CompanyInsolvencyInformationUriBuilder().Build("SC/171417");

            uri.ShouldBe(new Uri("company/SC%2F171417/insolvency", UriKind.Relative));
        }
    }
}

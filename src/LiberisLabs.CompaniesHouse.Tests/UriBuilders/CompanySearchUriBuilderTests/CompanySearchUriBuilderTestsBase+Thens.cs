using System;
using System.Collections.Specialized;
using System.Web;
using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.Tests.UriBuilders.CompanySearchUriBuilderTests
{
    public abstract partial class CompanySearchUriBuilderTestsBase
    {
        public class Thens
        {
            private readonly CompanySearchUriBuilderTestsBase _companySearchUriBuilderTestsBase;

            public Thens(CompanySearchUriBuilderTestsBase companySearchUriBuilderTestsBase)
            {
                _companySearchUriBuilderTestsBase = companySearchUriBuilderTestsBase;
            }

            public void TheUriQueryStringContainsTheQuery()
            {
                var query = GetQuery();

                Assert.That(query["q"], Is.EqualTo(_companySearchUriBuilderTestsBase.Query));
            }

            public void TheUriQueryStringDoesNotContainsTheItemsPerPage()
            {
                var query = GetQuery();

                Assert.That(query["items_per_page"], Is.Null);
            }

            public void TheUriQueryStringContainsTheItemsPerPage()
            {
                var query = GetQuery();

                Assert.That(query["items_per_page"], Is.EqualTo(_companySearchUriBuilderTestsBase.ItemsPerPage.ToString()));
            }

            public void TheUriQueryStringContainsTheStartIndex()
            {
                var query = GetQuery();

                Assert.That(query["start_index"], Is.EqualTo(_companySearchUriBuilderTestsBase.StartIndex.ToString()));
            }

            public void TheUriQueryStringDoesNotContainsTheStartIndex()
            {
                var query = GetQuery();

                Assert.That(query["start_index"], Is.Null);
            }

            protected NameValueCollection GetQuery()
            {
                var uri = new Uri(_companySearchUriBuilderTestsBase._baseUri, _companySearchUriBuilderTestsBase._actualUri);
                var query = HttpUtility.ParseQueryString(uri.Query);
                return query;
            }
        }


    }
}

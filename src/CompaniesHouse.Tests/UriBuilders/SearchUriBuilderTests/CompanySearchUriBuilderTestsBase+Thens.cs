using System;
using System.Collections.Specialized;
using System.Web;
using NUnit.Framework;

namespace CompaniesHouse.Tests.UriBuilders.SearchUriBuilderTests
{
    public abstract partial class SearchUriBuilderTestsBase
    {
        public class Thens
        {
            private readonly SearchUriBuilderTestsBase _searchUriBuilderTestsBase;

            public Thens(SearchUriBuilderTestsBase searchUriBuilderTestsBase)
            {
                _searchUriBuilderTestsBase = searchUriBuilderTestsBase;
            }

            public void TheUriQueryStringContainsTheQuery()
            {
                var query = GetQuery();

                Assert.That(query["q"], Is.EqualTo(_searchUriBuilderTestsBase.Query));
            }

            public void TheUriQueryStringDoesNotContainsTheItemsPerPage()
            {
                var query = GetQuery();

                Assert.That(query["items_per_page"], Is.Null);
            }

            public void TheUriQueryStringContainsTheItemsPerPage()
            {
                var query = GetQuery();

                Assert.That(query["items_per_page"], Is.EqualTo(_searchUriBuilderTestsBase.ItemsPerPage.ToString()));
            }

            public void TheUriQueryStringContainsTheStartIndex()
            {
                var query = GetQuery();

                Assert.That(query["start_index"], Is.EqualTo(_searchUriBuilderTestsBase.StartIndex.ToString()));
            }

            public void TheUriQueryStringDoesNotContainsTheStartIndex()
            {
                var query = GetQuery();

                Assert.That(query["start_index"], Is.Null);
            }

            protected NameValueCollection GetQuery()
            {
                var uri = new Uri(_searchUriBuilderTestsBase._baseUri, _searchUriBuilderTestsBase._actualUri);
                var query = HttpUtility.ParseQueryString(uri.Query);
                return query;
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
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

                Assert.That(query["q"].FirstOrDefault(), Is.EqualTo(_searchUriBuilderTestsBase.Query));
            }

            public void TheUriQueryStringDoesNotContainsTheItemsPerPage()
            {
                var query = GetQuery();

                Assert.That(query.ContainsKey("items_per_page"), Is.False);
            }

            public void TheUriQueryStringContainsTheItemsPerPage()
            {
                var query = GetQuery();

                Assert.That(query["items_per_page"].FirstOrDefault(), Is.EqualTo(_searchUriBuilderTestsBase.ItemsPerPage.ToString()));
            }

            public void TheUriQueryStringContainsTheStartIndex()
            {
                var query = GetQuery();

                Assert.That(query["start_index"].FirstOrDefault(), Is.EqualTo(_searchUriBuilderTestsBase.StartIndex.ToString()));
            }

            public void TheUriQueryStringDoesNotContainsTheStartIndex()
            {
                var query = GetQuery();

                Assert.That(query.ContainsKey("start_index"), Is.False);
            }

            protected Dictionary<string, StringValues> GetQuery()
            {
                var uri = new Uri(_searchUriBuilderTestsBase._baseUri, _searchUriBuilderTestsBase._actualUri);
                var query = QueryHelpers.ParseQuery(uri.Query);
                return query;
            }
        }


    }
}

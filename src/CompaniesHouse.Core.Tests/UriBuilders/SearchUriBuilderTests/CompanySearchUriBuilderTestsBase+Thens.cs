using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;


namespace CompaniesHouse.Core.Tests.UriBuilders.SearchUriBuilderTests
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

                Assert.That(query.ContainsKey("items_per_page"), Is.False);
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

                Assert.That(query.ContainsKey("start_index"), Is.False);
            }

            protected Dictionary<string, string> GetQuery()
            {
                return new Uri(_searchUriBuilderTestsBase._baseUri, _searchUriBuilderTestsBase._actualUri)
                    .ToString()
                    .Split('?')
                    .Last()
                    .Split('&')
                    .ToDictionary(GetKey, GetValue);

                string GetKey(string keyValue) => keyValue.Split('=')[0];
                string GetValue(string keyValue) => Uri.UnescapeDataString(keyValue.Split('=')[1]);
            }
        }
    }
}

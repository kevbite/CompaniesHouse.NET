using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;


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

                query["q"].ShouldBe(_searchUriBuilderTestsBase.Query);
            }

            public void TheUriQueryStringDoesNotContainsTheItemsPerPage()
            {
                var query = GetQuery();

                query.ContainsKey("items_per_page").ShouldBeFalse();
            }

            public void TheUriQueryStringContainsTheItemsPerPage()
            {
                var query = GetQuery();

                query["items_per_page"].ShouldBe(_searchUriBuilderTestsBase.ItemsPerPage.ToString());
            }

            public void TheUriQueryStringContainsTheStartIndex()
            {
                var query = GetQuery();

                query["start_index"].ShouldBe(_searchUriBuilderTestsBase.StartIndex.ToString());
            }

            public void TheUriQueryStringDoesNotContainsTheStartIndex()
            {
                var query = GetQuery();

                query.ContainsKey("start_index").ShouldBeFalse();
            }

            protected Dictionary<string, string> GetQuery()
            {
                return new Uri(_searchUriBuilderTestsBase._baseUri, _searchUriBuilderTestsBase.ActualUri)
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

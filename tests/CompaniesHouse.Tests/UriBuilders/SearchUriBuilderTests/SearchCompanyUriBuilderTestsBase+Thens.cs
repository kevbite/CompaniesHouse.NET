using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;

namespace CompaniesHouse.Tests.UriBuilders.SearchUriBuilderTests
{
    public abstract partial class SearchCompanyUriBuilderTestsBase
    {
        public class Thens
        {
            private readonly SearchCompanyUriBuilderTestsBase _tests;

            public Thens(SearchCompanyUriBuilderTestsBase tests)
            {
                _tests = tests;
            }

            public void TheUriQueryStringDoesNotContainRestrictions()
            {
                GetQuery().ContainsKey("restrictions").ShouldBeFalse();
            }

            public void TheUriQueryStringContainsRestrictions()
            {
                GetQuery()["restrictions"].ShouldBe(_tests.Restrictions);
            }

            private Dictionary<string, string> GetQuery()
            {
                return new Uri(_tests._baseUri, _tests.ActualUri)
                    .ToString()
                    .Split('?')
                    .Last()
                    .Split('&')
                    .ToDictionary(GetKey, GetValue);

                string GetKey(string keyValue) => keyValue.Split('=')[0];
                string GetValue(string keyValue) => keyValue.Contains('=') ? Uri.UnescapeDataString(keyValue.Split('=')[1]) : string.Empty;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CompaniesHouse.Tests.UriBuilders.AdvancedSearchCompanyUriBuilderTests
{
    public abstract partial class AdvancedSearchCompanyUriBuilderTestsBase
    {
        public class Thens
        {
            private readonly AdvancedSearchCompanyUriBuilderTestsBase _testBase;

            public Thens(AdvancedSearchCompanyUriBuilderTestsBase testBase)
            {
                _testBase = testBase;
            }

            public void TheUriQueryStringDoesNotContainsTheItemsPerPage()
            {
                var query = GetQuery();
                Assert.That(query.Contains("items_per_page"), Is.False);
            }

            public void TheUriQueryStringContainsTheItemsPerPage()
            {
                var query = GetQuery();
                Assert.That(query["items_per_page"].Single(), Is.EqualTo(_testBase.ItemsPerPage.ToString()));
            }

            public void TheUriQueryStringContainsTheStartIndex()
            {
                var query = GetQuery();
                Assert.That(query["start_index"].Single(), Is.EqualTo(_testBase.StartIndex.ToString()));
            }

            public void TheUriQueryStringDoesNotContainsTheStartIndex()
            {
                var query = GetQuery();
                Assert.That(query.Contains("start_index"), Is.False);
            }

            public void TheUriQueryStringContainsTheCompanyNameIncludes()
            {
                var query = GetQuery();
                Assert.That(query["company_name_includes"].Single(), Is.EqualTo(_testBase.CompanyNameIncludes));
            }

            public void TheUriQueryStringDoesNotContainsTheCompanyNameIncludes()
            {
                var query = GetQuery();
                Assert.That(query.Contains("company_name_includes"), Is.False);
            }

            public void TheUriQueryStringContainsTheCompanyNameExcludes()
            {
                var query = GetQuery();
                Assert.That(query["company_name_excludes"].Single(), Is.EqualTo(_testBase.CompanyNameExcludes));
            }

            public void TheUriQueryStringDoesNotContainsTheCompanyNameExcludes()
            {
                var query = GetQuery();
                Assert.That(query.Contains("company_name_excludes"), Is.False);
            }

            public void TheUriQueryStringContainsTheCompanyStatus()
            {
                var query = GetQuery();
                var expected = _testBase.CompanyStatus.Select(x => x.ToString().ToLowerInvariant()).ToArray();
                Assert.That(query["company_status"], Is.EquivalentTo(expected));
            }

            public void TheUriQueryStringDoesNotContainsTheCompanyStatus()
            {
                var query = GetQuery();
                Assert.That(query.Contains("company_status"), Is.False);
            }

            public void TheUriQueryStringContainsTheCompanySubtype()
            {
                var query = GetQuery();
                Assert.That(query.Contains("company_subtype"), Is.True);
            }

            public void TheUriQueryStringDoesNotContainsTheCompanySubtype()
            {
                var query = GetQuery();
                Assert.That(query.Contains("company_subtype"), Is.False);
            }

            public void TheUriQueryStringContainsTheCompanyType()
            {
                var query = GetQuery();
                Assert.That(query.Contains("company_type"), Is.True);
            }

            public void TheUriQueryStringDoesNotContainsTheCompanyType()
            {
                var query = GetQuery();
                Assert.That(query.Contains("company_type"), Is.False);
            }

            public void TheUriQueryStringContainsTheDissolvedFrom()
            {
                var query = GetQuery();
                Assert.That(query.Contains("dissolved_from"), Is.True);
            }

            public void TheUriQueryStringDoesNotContainsTheDissolvedFrom()
            {
                var query = GetQuery();
                Assert.That(query.Contains("dissolved_from"), Is.False);
            }

            public void TheUriQueryStringContainsTheDissolvedTo()
            {
                var query = GetQuery();
                Assert.That(query.Contains("dissolved_to"), Is.True);
            }

            public void TheUriQueryStringDoesNotContainsTheDissolvedTo()
            {
                var query = GetQuery();
                Assert.That(query.Contains("dissolved_to"), Is.False);
            }

            public void TheUriQueryStringContainsTheIncorporatedFrom()
            {
                var query = GetQuery();
                Assert.That(query.Contains("incorporated_from"), Is.True);
            }

            public void TheUriQueryStringDoesNotContainsTheIncorporatedFrom()
            {
                var query = GetQuery();
                Assert.That(query.Contains("incorporated_from"), Is.False);
            }

            public void TheUriQueryStringContainsTheIncorporatedTo()
            {
                var query = GetQuery();
                Assert.That(query.Contains("incorporated_to"), Is.True);
            }

            public void TheUriQueryStringDoesNotContainsTheIncorporatedTo()
            {
                var query = GetQuery();
                Assert.That(query.Contains("incorporated_to"), Is.False);
            }

            public void TheUriQueryStringContainsTheLocation()
            {
                var query = GetQuery();
                Assert.That(query["location"].Single(), Is.EqualTo(_testBase.Location));
            }

            public void TheUriQueryStringDoesNotContainsTheLocation()
            {
                var query = GetQuery();
                Assert.That(query.Contains("location"), Is.False);
            }

            public void TheUriQueryStringContainsTheSicCodes()
            {
                var query = GetQuery();
                Assert.That(query.Contains("sic_codes"), Is.True);
            }

            public void TheUriQueryStringDoesNotContainsTheSicCodes()
            {
                var query = GetQuery();
                Assert.That(query.Contains("sic_codes"), Is.False);
            }

            protected ILookup<string, string> GetQuery()
            {
                return new Uri(_testBase._baseUri, _testBase._actualUri)
                    .ToString()
                    .Split('?')
                    .LastOrDefault("")
                    .Split('&', StringSplitOptions.RemoveEmptyEntries)
                    .ToLookup(GetKey, GetValue);

                string GetKey(string keyValue) => keyValue.Split('=')[0];
                string GetValue(string keyValue) => Uri.UnescapeDataString(keyValue.Split('=')[1]);
            }
        }
    }
}
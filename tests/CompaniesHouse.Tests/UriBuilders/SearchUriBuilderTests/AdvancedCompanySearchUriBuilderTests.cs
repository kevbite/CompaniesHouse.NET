using System;
using CompaniesHouse.Request;
using CompaniesHouse.Response;
using CompaniesHouse.UriBuilders;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.SearchUriBuilderTests
{
    public class AdvancedCompanySearchUriBuilderTests
    {
        [Fact]
        public void Build_IncludesConfiguredParameters()
        {
            var sut = new AdvancedCompanySearchUriBuilder("advanced-search/companies");

            var uri = sut.Build(new AdvancedCompanySearchRequest
            {
                CompanyNameIncludes = "abc & co",
                CompanyNameExcludes = "beta ltd",
                CompanyStatuses = new[] { CompanyStatus.Active, CompanyStatus.Dissolved },
                CompanySubtypes = new[] { CompanySubtype.CommunityInterestCompany, CompanySubtype.PrivateFundLimitedPartnership },
                CompanyTypes = new[] { CompanyType.Ltd, CompanyType.PrivateLimitedGuarantNsc },
                DissolvedFrom = new DateTime(2020, 01, 02),
                DissolvedTo = new DateTime(2020, 03, 04),
                IncorporatedFrom = new DateTime(2010, 05, 06),
                IncorporatedTo = new DateTime(2011, 07, 08),
                Location = "London & Surrey",
                SicCodes = new[] { "62012", "62020" },
                Size = 100,
                StartIndex = 30,
            });

            uri.ToString().ShouldBe("advanced-search/companies?company_name_includes=abc%20%26%20co&company_name_excludes=beta%20ltd&company_status=active%2Cdissolved&company_subtype=community-interest-company%2Cprivate-fund-limited-partnership&company_type=ltd%2Cprivate-limited-guarant-nsc&dissolved_from=2020-01-02&dissolved_to=2020-03-04&incorporated_from=2010-05-06&incorporated_to=2011-07-08&location=London%20%26%20Surrey&sic_codes=62012%2C62020&size=100&start_index=30");
        }

        [Fact]
        public void Build_OmitsParametersThatAreNotSupplied()
        {
            var sut = new AdvancedCompanySearchUriBuilder("advanced-search/companies");

            var uri = sut.Build(new AdvancedCompanySearchRequest());

            uri.ShouldBe(new Uri("advanced-search/companies", UriKind.Relative));
        }
    }
}

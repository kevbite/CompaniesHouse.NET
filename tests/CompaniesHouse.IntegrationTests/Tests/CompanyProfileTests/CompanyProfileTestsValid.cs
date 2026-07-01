using System.Threading.Tasks;
using CompaniesHouse.Response;
using CompaniesHouse.Response.CompanyProfile;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyProfileTests
{

    public class CompanyProfileTestsValid : CompanyProfileTestsBase
    {
        // Google UK company number, unlikely to go away soon
        private const string ValidCompanyNumber = "03977902";


        protected override async Task When()
        {
            await WhenRetrievingAValidCompanyProfile()
                ;
        }

        [Fact]
        public void ThenTheProfileIsReturned()
        {
            _result.Data.CompanyName.ShouldNotBeEmpty();
        }

        [Fact]
        public async Task ThenAPlainCompanyProfileIncludesExemptionsAndHasSuperSecurePscs()
        {
            var result = await _client.GetCompanyProfileAsync("00445790");

            result.Data.ShouldNotBeNull();
            result.Data.CompanyStatus.ShouldBe(CompanyStatus.Active);
            result.Data.Type.ShouldBe(CompanyType.Plc);
            result.Data.Links.ShouldNotBeNull();
            result.Data.Links.Exemptions.ShouldNotBeNullOrWhiteSpace();
            result.Data.HasSuperSecurePscs.ShouldBe(false);
        }

        [Fact]
        public async Task ThenAForeignCompanyProfileIncludesForeignCompanyDetails()
        {
            var result = await _client.GetCompanyProfileAsync("FC040879");

            result.Data.ShouldNotBeNull();
            result.Data.Type.ShouldBe(CompanyType.OverseaCompany);
            result.Data.ExternalRegistrationNumber.ShouldBe("198600479406");
            result.Data.ForeignCompanyDetails.ShouldNotBeNull();
            result.Data.ForeignCompanyDetails.AccountingRequirement.ShouldNotBeNull();
            result.Data.ForeignCompanyDetails.AccountingRequirement.ForeignAccountType.ShouldBe(
                ForeignAccountType.AccountingRequirementsOfOriginatingCountryApply);
            result.Data.ForeignCompanyDetails.AccountingRequirement.TermsOfAccountPublication.ShouldBe(
                TermsOfAccountPublication.AccountsPublicationDateSuppliedByCompany);
            result.Data.ForeignCompanyDetails.IsACreditFinancialInstitution.ShouldBe(true);
            result.Data.Links.UkEstablishments.ShouldNotBeNullOrWhiteSpace();
        }

        [Fact]
        public async Task ThenACommunityInterestCompanyProfileIncludesSubtype()
        {
            var result = await _client.GetCompanyProfileAsync("13507518");

            result.Data.ShouldNotBeNull();
            result.Data.IsCommunityInterestCompany.ShouldBe(true);
            result.Data.Subtype.ShouldBe(CompanySubtype.CommunityInterestCompany);
        }

        private async Task WhenRetrievingAValidCompanyProfile()
        {
            _result = await _client.GetCompanyProfileAsync(ValidCompanyNumber)
                ;
        }
    }
}

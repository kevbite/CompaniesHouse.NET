using System.Threading.Tasks;
using CompaniesHouse.Response.CompanyProfile;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyProfileTests
{
    [TestFixture]
    public class CompanyProfileTestsValidForeignCompany : CompanyProfileTestsBase
    {
        // Apple DISTRIBUTION company number, unlikely to go away soon
        private const string ValidCompanyNumber = "FC031666";

        [SetUp]
        protected override async Task When()
        {
            await WhenRetrievingAValidCompanyProfile()
                .ConfigureAwait(false);
        }

        [Test]
        public void ThenTheProfileIsReturned()
        {
            Assert.That(_result.Data.CompanyName, Is.Not.Empty);
        }
        
        [Test]
        public void ThenTheProfileForeignCompanyDetailsIsReturned()
        {
            Assert.That(_result.Data.ForeignCompanyDetails, Is.Not.Null);
            Assert.That(_result.Data.ForeignCompanyDetails.AccountingRequirement.ForeignAccountType, 
                Is.EqualTo(ForeignAccountType.AccountingRequirementsOfOriginatingCountryApply));
            Assert.That(_result.Data.ForeignCompanyDetails.AccountingRequirement.TermsOfAccountPublication, 
                Is.EqualTo(TermsOfAccountPublication.AccountingPublicationDateDoesNotNeedToBeSuppliedByCompany));
        }


        private async Task WhenRetrievingAValidCompanyProfile()
        {
            _result = await _client.GetCompanyProfileAsync(ValidCompanyNumber)
                .ConfigureAwait(false);
        }
    }
}

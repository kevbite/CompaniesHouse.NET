using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyInsolvencyInformationTests
{

    public class CompanyInsolvencyInformationTestsValid : CompanyInsolvencyInformationTestBase
    {
        private const string ValidCompanyNumber = "08749409";

        protected override async Task When() =>
            Result = await Client.GetCompanyInsolvencyInformationAsync(ValidCompanyNumber);

        [IntegrationFact]
        public void ThenTheItemsAreReturned() => Result.Data.ShouldNotBeNull();

        [IntegrationFact]
        public void ThenObservedStatusesAndCaseTypesAreReturned()
        {
            Result.Data.Cases.ShouldNotBeNull();
            Result.Data.Cases.ShouldNotBeEmpty();
            Result.Data.Cases[0].Type.Value.ShouldNotBeNullOrWhiteSpace();
        }
    }
}

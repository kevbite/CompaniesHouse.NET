using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyInsolvencyInformationTests
{
    
    public class CompanyInsolvencyInformationTestsInvalid : CompanyInsolvencyInformationTestBase
    {
        private const string InvalidCompanyNumber = "ABC00000";

        protected override async Task When() =>
            Result = await Client.GetCompanyInsolvencyInformationAsync(InvalidCompanyNumber);

        [IntegrationFact]
        public void ThenTheItemsAreNull() => Result.Data.ShouldBeNull();
    }
}

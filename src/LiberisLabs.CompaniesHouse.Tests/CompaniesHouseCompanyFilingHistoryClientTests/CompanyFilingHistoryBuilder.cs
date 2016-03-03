using LiberisLabs.CompaniesHouse.Tests.ResourceBuilders;
using Ploeh.AutoFixture;

namespace LiberisLabs.CompaniesHouse.Tests.CompaniesHouseCompanyFilingHistoryClientTests
{
    public class CompanyFilingHistoryBuilder
    {
        public CompanyFilingHistory Build()
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<FilingHistoryItem>(x => x.DateOfProcessing));

            var filingHistory = fixture.Build<CompanyFilingHistory>()
               .Create();

            return filingHistory;
        }
    }
}

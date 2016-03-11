using System.Linq;
using LiberisLabs.CompaniesHouse.Tests.ResourceBuilders;
using Ploeh.AutoFixture;

namespace LiberisLabs.CompaniesHouse.Tests.CompaniesHouseCompanyProfileClientTests
{
    public class CompanyProfileBuilder
    {
        public CompanyProfile Build(CompaniesHouseCompanyProfileClientTestCase testCase)
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<LastAccounts>(x => x.MadeUpTo));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<Accounts>(x => x.NextMadeUpTo));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<Accounts>(x => x.NextDue));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<AnnualReturn>(x => x.LastMadeUpTo));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<AnnualReturn>(x => x.NextDue));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<AnnualReturn>(x => x.NextMadeUpTo));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<CompanyProfile>(x => x.DateOfCreation));
            fixture.Customizations.Add(
                new UniversalDateSpecimenBuilder<CompanyProfile>(x => x.DateOfDissolution));
            fixture.Customizations.Add(
                new UniversalDateSpecimenBuilder<CompanyProfile>(x => x.LastFullMembersListDate));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<Officer>(x => x.AppointedOn));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<Officer>(x => x.ResignedOn));


            var lastAccounts = fixture.Build<LastAccounts>()
                .With(x => x.Type, testCase.LastAccountsType)
                .Create();

            var accounts = fixture.Build<Accounts>()
                .With(x => x.LastAccounts, lastAccounts)
                .Create();

            var officers = EnumerationMappings.PossibleOfficerRoles.Keys.Select(x => fixture.Build<Officer>()
                .With(y => y.OfficerRole, x)
                .Create()).ToArray();

            var officerSummary = fixture.Build<OfficerSummary>().With(x => x.Officers, officers).Create();

            var companyProfile = fixture.Build<CompanyProfile>()
                .With(x => x.Accounts, accounts)
                .With(x => x.CompanyStatus, testCase.CompanyStatus)
                .With(x => x.CompanyStatusDetail, testCase.CompanyStatusDetail)
                .With(x => x.Jurisdiction, testCase.Jurisdiction)
                .With(x => x.Type, testCase.Type)
                .With(x => x.OfficerSummary, officerSummary)
                .Create();

            return companyProfile;
        }
    }
}
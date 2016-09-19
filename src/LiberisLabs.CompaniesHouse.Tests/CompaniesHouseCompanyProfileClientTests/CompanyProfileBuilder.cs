using System.Linq;
using LiberisLabs.CompaniesHouse.Response.CompanyProfile;
using Ploeh.AutoFixture;
using Accounts = LiberisLabs.CompaniesHouse.Tests.ResourceBuilders.Accounts;
using AnnualReturn = LiberisLabs.CompaniesHouse.Tests.ResourceBuilders.AnnualReturn;
using CompanyProfile = LiberisLabs.CompaniesHouse.Tests.ResourceBuilders.CompanyProfile;
using ConfirmationStatement = LiberisLabs.CompaniesHouse.Tests.ResourceBuilders.ConfirmationStatement;
using LastAccounts = LiberisLabs.CompaniesHouse.Tests.ResourceBuilders.LastAccounts;
using Officer = LiberisLabs.CompaniesHouse.Tests.ResourceBuilders.Officer;
using OfficerSummary = LiberisLabs.CompaniesHouse.Tests.ResourceBuilders.OfficerSummary;

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

            fixture.Customizations.Add(new UniversalNullableDateSpecimenBuilder<ConfirmationStatement>(x => x.NextMadeUpTo));
            fixture.Customizations.Add(new UniversalNullableDateSpecimenBuilder<ConfirmationStatement>(x => x.LastMadeUpTo));
            fixture.Customizations.Add(new UniversalNullableDateSpecimenBuilder<ConfirmationStatement>(x => x.NextDue));

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
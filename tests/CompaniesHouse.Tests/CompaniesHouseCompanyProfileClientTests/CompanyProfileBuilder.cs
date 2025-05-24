using AutoFixture;

namespace CompaniesHouse.Tests.CompaniesHouseCompanyProfileClientTests
{
    public class CompanyProfileBuilder
    {
        public ResourceBuilders.CompanyProfile Build(CompaniesHouseCompanyProfileClientTestCase testCase)
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<ResourceBuilders.LastAccounts>(x => x.MadeUpTo));
            fixture.Customizations.Add(new UniversalNullableDateSpecimenBuilder<ResourceBuilders.LastAccounts>(x => x.PeriodEndOn));
            fixture.Customizations.Add(new UniversalNullableDateSpecimenBuilder<ResourceBuilders.LastAccounts>(x => x.PeriodStartOn));
            fixture.Customizations.Add(new UniversalNullableDateSpecimenBuilder<ResourceBuilders.NextAccounts>(x => x.DueOn));
            fixture.Customizations.Add(new UniversalNullableDateSpecimenBuilder<ResourceBuilders.NextAccounts>(x => x.PeriodEndOn));
            fixture.Customizations.Add(new UniversalNullableDateSpecimenBuilder<ResourceBuilders.NextAccounts>(x => x.PeriodStartOn));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<ResourceBuilders.Accounts>(x => x.NextMadeUpTo));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<ResourceBuilders.Accounts>(x => x.NextDue));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<ResourceBuilders.AnnualReturn>(x => x.LastMadeUpTo));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<ResourceBuilders.AnnualReturn>(x => x.NextDue));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<ResourceBuilders.AnnualReturn>(x => x.NextMadeUpTo));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<ResourceBuilders.CompanyProfile>(x => x.DateOfCreation));
            fixture.Customizations.Add(
                new UniversalDateSpecimenBuilder<ResourceBuilders.CompanyProfile>(x => x.DateOfCessation));
            fixture.Customizations.Add(
                new UniversalDateSpecimenBuilder<ResourceBuilders.CompanyProfile>(x => x.LastFullMembersListDate));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<ResourceBuilders.Officer>(x => x.AppointedOn));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<ResourceBuilders.Officer>(x => x.ResignedOn));

            fixture.Customizations.Add(new UniversalNullableDateSpecimenBuilder<ResourceBuilders.ConfirmationStatement>(x => x.NextMadeUpTo));
            fixture.Customizations.Add(new UniversalNullableDateSpecimenBuilder<ResourceBuilders.ConfirmationStatement>(x => x.LastMadeUpTo));
            fixture.Customizations.Add(new UniversalNullableDateSpecimenBuilder<ResourceBuilders.ConfirmationStatement>(x => x.NextDue));

            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<ResourceBuilders.PreviousCompanyName>(x => x.CeasedOn));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<ResourceBuilders.PreviousCompanyName>(x => x.EffectiveFrom));

            var lastAccounts = fixture.Build<ResourceBuilders.LastAccounts>()
                .With(x => x.Type, testCase.LastAccountsType)
                .Create();

            var nextAccounts = fixture.Build<ResourceBuilders.NextAccounts>()
                .Create();

            var previousCompanyNames = fixture.Build<ResourceBuilders.PreviousCompanyName>()
                .CreateMany().ToArray();

            var accounts = fixture.Build<ResourceBuilders.Accounts>()
                .With(x => x.LastAccounts, lastAccounts)
                .With(x => x.NextAccounts, nextAccounts)
                .Create();

            var officers = EnumerationMappings.PossibleOfficerRoles.Keys.Select(x => fixture.Build<ResourceBuilders.Officer>()
                .With(y => y.OfficerRole, x)
                .Create()).ToArray();

            var officerSummary = fixture.Build<ResourceBuilders.OfficerSummary>().With(x => x.Officers, officers).Create();

            var accountingRequirement = fixture.Build<ResourceBuilders.AccountingRequirement>()
                .With(x => x.ForeignAccountType, "")
                .With(x => x.TermsOfAccountPublication, "")
                .Create();
            
            var foreignCompanyDetails = fixture.Build<ResourceBuilders.ForeignCompanyDetails>()
                .With(x => x.AccountingRequirement, accountingRequirement)
                .Create();
            
            var companyProfile = fixture.Build<ResourceBuilders.CompanyProfile>()
                .With(x => x.Accounts, accounts)
                .With(x => x.CompanyStatus, testCase.CompanyStatus)
                .With(x => x.CompanyStatusDetail, testCase.CompanyStatusDetail)
                .With(x => x.Jurisdiction, testCase.Jurisdiction)
                .With(x => x.Type, testCase.Type)
                .With(x => x.OfficerSummary, officerSummary)
                .With(x => x.PreviousCompanyNames, previousCompanyNames)
                .With(x => x.ForeignCompanyDetails, foreignCompanyDetails)
                .Create();

            return companyProfile;
        }
    }
}

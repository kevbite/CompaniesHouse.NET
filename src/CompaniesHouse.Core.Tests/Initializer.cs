using CompaniesHouse.Core.Response;
using CompaniesHouse.Core.Response.CompanyProfile;
using CompaniesHouse.Core.Response.Officers;
using CompaniesHouse.Core.Response.PersonsWithSignificantControl;
using CompaniesHouse.Core.Tests.MapProviders;
using FluentAssertions;
using NUnit.Framework;

namespace CompaniesHouse.Core.Tests
{
    [SetUpFixture]
    public class Initializer
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            AssertionOptions.EquivalencySteps.Insert<ComparingEnumWith<CompanyTypesMapProvider, CompanyType>>();
            AssertionOptions.EquivalencySteps.Insert<ComparingEnumWith<CompanyStatusMapProvider, CompanyStatus>>();
            AssertionOptions.EquivalencySteps.Insert<ComparingEnumWith<CompanyStatusDetailMapProvider, CompanyStatusDetail>>();
            AssertionOptions.EquivalencySteps.Insert<ComparingEnumWith<LastAccountsTypeMapProvider, LastAccountsType>>();
            AssertionOptions.EquivalencySteps.Insert<ComparingEnumWith<JurisdictionMapProvider, Jurisdiction>>();
            AssertionOptions.EquivalencySteps.Insert<ComparingEnumWith<OfficerRoleMapProvider, OfficerRole>>();
            AssertionOptions.EquivalencySteps.Insert<ComparingEnumWith<FilingCategoriesMapProvider, FilingCategory>>();
            AssertionOptions.EquivalencySteps.Insert<ComparingEnumWith<FilingSubcategoriesMapProvider, FilingSubcategory>>();
            AssertionOptions.EquivalencySteps.Insert<ComparingArrayEnumWith<FilingSubcategoriesMapProvider, FilingSubcategory>>();
            AssertionOptions.EquivalencySteps.Insert<ComparingEnumWith<ResolutionCategoriesMapProvider, ResolutionCategory>>();
            AssertionOptions.EquivalencySteps.Insert<ComparingEnumWith<FilingHistoryStatusMapProvider, FilingHistoryStatus>>();
            AssertionOptions.EquivalencySteps.Insert<ComparingEnumWith<PersonWithSignificantControlKindMapProvider, PersonWithSignificantControlKind>>();
        }
    }
}

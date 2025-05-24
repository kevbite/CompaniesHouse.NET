using CompaniesHouse.Response;
using CompaniesHouse.Response.CompanyProfile;
using CompaniesHouse.Response.Officers;
using CompaniesHouse.Response.PersonsWithSignificantControl;
using CompaniesHouse.Tests.MapProviders;
using FluentAssertions;
using NUnit.Framework;

namespace CompaniesHouse.Tests
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
            AssertionOptions.EquivalencySteps.Insert<ComparingEnumWith<AssetsCeasedReleasedMapProvider, AssetsCeasedReleased>>();
            AssertionOptions.EquivalencySteps.Insert<ComparingEnumWith<ChargeStatusMapProvider, ChargeStatus>>();
            AssertionOptions.EquivalencySteps.Insert<ComparingEnumWith<ClassificationChargeTypeMapProvider, ClassificationChargeType>>();
            AssertionOptions.EquivalencySteps.Insert<ComparingEnumWith<ParticularTypeMapProvider, ParticularType>>();
            AssertionOptions.EquivalencySteps.Insert<ComparingEnumWith<SecureDetailTypeMapProvider, SecuredDetailType>>();
            AssertionOptions.EquivalencySteps.Insert<ComparingEnumWith<ForeignAccountTypeMapProvider, ForeignAccountType>>();
            AssertionOptions.EquivalencySteps.Insert<ComparingEnumWith<TermsOfAccountPublicationMapProvider, TermsOfAccountPublication>>();
        }
    }
}

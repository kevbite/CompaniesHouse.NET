using System;
using CompaniesHouse.UriBuilders;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.UriBuilders.PersonsWithSignificantControlDetailsUriBuilderTests
{
    public class PersonsWithSignificantControlDetailsUriBuilderTests
    {
        private readonly PersonsWithSignificantControlDetailsUriBuilder _builder = new();

        [Fact]
        public void BuildIndividual_EncodesIds()
        {
            _builder.BuildIndividual("00/123", "a/b")
                .ShouldBe(new Uri("company/00%2F123/persons-with-significant-control/individual/a%2Fb", UriKind.Relative));
        }

        [Fact]
        public void BuildIndividualBeneficialOwner_EncodesIds()
        {
            _builder.BuildIndividualBeneficialOwner("00/123", "a/b")
                .ShouldBe(new Uri("company/00%2F123/persons-with-significant-control/individual-beneficial-owner/a%2Fb", UriKind.Relative));
        }

        [Fact]
        public void BuildCorporateEntity_EncodesIds()
        {
            _builder.BuildCorporateEntity("00/123", "a/b")
                .ShouldBe(new Uri("company/00%2F123/persons-with-significant-control/corporate-entity/a%2Fb", UriKind.Relative));
        }

        [Fact]
        public void BuildCorporateEntityBeneficialOwner_EncodesIds()
        {
            _builder.BuildCorporateEntityBeneficialOwner("00/123", "a/b")
                .ShouldBe(new Uri("company/00%2F123/persons-with-significant-control/corporate-entity-beneficial-owner/a%2Fb", UriKind.Relative));
        }

        [Fact]
        public void BuildLegalPerson_EncodesIds()
        {
            _builder.BuildLegalPerson("00/123", "a/b")
                .ShouldBe(new Uri("company/00%2F123/persons-with-significant-control/legal-person/a%2Fb", UriKind.Relative));
        }

        [Fact]
        public void BuildLegalPersonBeneficialOwner_EncodesIds()
        {
            _builder.BuildLegalPersonBeneficialOwner("00/123", "a/b")
                .ShouldBe(new Uri("company/00%2F123/persons-with-significant-control/legal-person-beneficial-owner/a%2Fb", UriKind.Relative));
        }

        [Fact]
        public void BuildStatementsList_IncludesPagingAndOptionalRegisterView()
        {
            _builder.BuildStatementsList("00/123", 25, 10, true)
                .ShouldBe(new Uri("company/00%2F123/persons-with-significant-control-statements?items_per_page=10&start_index=25&register_view=true", UriKind.Relative));
        }

        [Fact]
        public void BuildStatement_EncodesStatementId()
        {
            _builder.BuildStatement("00/123", "a/b")
                .ShouldBe(new Uri("company/00%2F123/persons-with-significant-control-statements/a%2Fb", UriKind.Relative));
        }

        [Fact]
        public void BuildSuperSecure_EncodesId()
        {
            _builder.BuildSuperSecure("00/123", "a/b")
                .ShouldBe(new Uri("company/00%2F123/persons-with-significant-control/super-secure/a%2Fb", UriKind.Relative));
        }

        [Fact]
        public void BuildSuperSecureBeneficialOwner_EncodesId()
        {
            _builder.BuildSuperSecureBeneficialOwner("00/123", "a/b")
                .ShouldBe(new Uri("company/00%2F123/persons-with-significant-control/super-secure-beneficial-owner/a%2Fb", UriKind.Relative));
        }
    }
}

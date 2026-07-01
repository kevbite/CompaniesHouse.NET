using System.Text.Json;
using CompaniesHouse.Response.Officers;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.ResponseValueTypes
{
    public class OfficerRoleTests
    {
        [Theory]
        [InlineData("cic-manager")]
        [InlineData("corporate-director")]
        [InlineData("corporate-llp-designated-member")]
        [InlineData("corporate-llp-member")]
        [InlineData("corporate-manager-of-an-eeig")]
        [InlineData("corporate-managing-officer")]
        [InlineData("corporate-member-of-a-management-organ")]
        [InlineData("corporate-member-of-a-supervisory-organ")]
        [InlineData("corporate-member-of-an-administrative-organ")]
        [InlineData("corporate-nominee-director")]
        [InlineData("corporate-nominee-secretary")]
        [InlineData("corporate-secretary")]
        [InlineData("director")]
        [InlineData("general-partner-in-a-limited-partnership")]
        [InlineData("corporate-general-partner-in-a-limited-partnership")]
        [InlineData("limited-partner-in-a-limited-partnership")]
        [InlineData("corporate-limited-partner-in-a-limited-partnership")]
        [InlineData("judicial-factor")]
        [InlineData("llp-designated-member")]
        [InlineData("llp-member")]
        [InlineData("manager-of-an-eeig")]
        [InlineData("managing-officer")]
        [InlineData("member-of-a-management-organ")]
        [InlineData("member-of-a-supervisory-organ")]
        [InlineData("member-of-an-administrative-organ")]
        [InlineData("nominee-director")]
        [InlineData("nominee-secretary")]
        [InlineData("person-authorised-to-accept")]
        [InlineData("person-authorised-to-represent")]
        [InlineData("person-authorised-to-represent-and-accept")]
        [InlineData("receiver-and-manager")]
        [InlineData("secretary")]
        public void Deserializing_KnownValue_RoundTripsAndIsKnown(string value)
        {
            var json = $"\"{value}\"";

            var role = JsonSerializer.Deserialize<OfficerRole>(json, CompaniesHouseJsonSerializerOptions.Default);

            role.Value.ShouldBe(value);
            role.IsKnown.ShouldBeTrue();
            role.HasValue.ShouldBeTrue();

            var reserialized = JsonSerializer.Serialize(role, CompaniesHouseJsonSerializerOptions.Default);
            reserialized.ShouldBe(json);
        }

        [Fact]
        public void Deserializing_UnknownValue_DoesNotThrowAndPreservesRawValue()
        {
            const string json = "\"some-brand-new-officer-role\"";

            var role = JsonSerializer.Deserialize<OfficerRole>(json, CompaniesHouseJsonSerializerOptions.Default);

            role.Value.ShouldBe("some-brand-new-officer-role");
            role.IsKnown.ShouldBeFalse();
            role.HasValue.ShouldBeTrue();
            role.Description.ShouldBeNull();

            var reserialized = JsonSerializer.Serialize(role, CompaniesHouseJsonSerializerOptions.Default);
            reserialized.ShouldBe(json);
        }

        [Fact]
        public void Deserializing_Null_ReturnsDefaultWithNoValue()
        {
            var role = JsonSerializer.Deserialize<OfficerRole>("null", CompaniesHouseJsonSerializerOptions.Default);

            role.ShouldBe(default);
            role.HasValue.ShouldBeFalse();
            role.Value.ShouldBe(string.Empty);
            role.IsKnown.ShouldBeFalse();

            var reserialized = JsonSerializer.Serialize(role, CompaniesHouseJsonSerializerOptions.Default);
            reserialized.ShouldBe("null");
        }

        [Fact]
        public void KnownValues_CompareEqualToStaticMembers()
        {
            new OfficerRole("director").ShouldBe(OfficerRole.Director);
            new OfficerRole("secretary").ShouldBe(OfficerRole.Secretary);
            new OfficerRole("corporate-general-partner-in-a-limited-partnership")
                .ShouldBe(OfficerRole.CorporateGeneralPartnerInALimitedPartnership);

            (OfficerRole.Director == new OfficerRole("director")).ShouldBeTrue();
            (OfficerRole.Director == OfficerRole.Secretary).ShouldBeFalse();
        }

        [Fact]
        public void SwitchExpression_MatchesOnKnownValues()
        {
            var role = new OfficerRole("director");

            var description = role switch
            {
                _ when role == OfficerRole.Director => "is a director",
                _ when role == OfficerRole.Secretary => "is a secretary",
                _ => "something else",
            };

            description.ShouldBe("is a director");
        }

        [Fact]
        public void Description_ReturnsFriendlyTextForKnownValues()
        {
            OfficerRole.CorporateManagingOfficer.Description.ShouldBe("Managing Officer");
            OfficerRole.PersonAuthorisedToRepresentAndAccept.Description.ShouldBe("Person Authorised to Represent and Accept");
        }

        [Fact]
        public void ToString_ReturnsRawValue()
        {
            OfficerRole.Director.ToString().ShouldBe("director");
            default(OfficerRole).ToString().ShouldBe(string.Empty);
        }
    }
}

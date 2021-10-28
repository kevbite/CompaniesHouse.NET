using AutoFixture;

namespace CompaniesHouse.Tests.CompaniesHouseOfficersAppointmentClientTests
{
    public static class OfficerBuilder
    {
        public static ResourceBuilders.Officer Build(CompaniesHouseOfficerByAppointmentTestCase testCase)
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<ResourceBuilders.Officer>(x => x.AppointedOn));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<ResourceBuilders.Officer>(x => x.ResignedOn));
            
            return fixture
                .Build<ResourceBuilders.Officer>()
                .With(x => x.OfficerRole, testCase.OfficerRole)
                .Create();
        }
    }
}
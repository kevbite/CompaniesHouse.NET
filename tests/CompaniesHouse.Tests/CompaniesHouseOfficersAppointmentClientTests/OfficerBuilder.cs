using AutoFixture;
using CompaniesHouse.Response.Officers;

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
                .With(x => x.Links, 
                    fixture
                        .Build<OfficerLinks>()
                        .With(x => x.Officer, 
                            fixture
                                .Build<OfficerAppointmentLink>()
                                .With(x => x.AppointmentsResource, "/officer/xyz/appointments")
                                .Create())
                        .Create())
                .With(x => x.OfficerRole, testCase.OfficerRole)
                .Create();
        }
    }
}
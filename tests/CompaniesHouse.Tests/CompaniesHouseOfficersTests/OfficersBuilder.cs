using System;
using System.Linq;
using CompaniesHouse.Response.Officers;
using AutoFixture;
using Officer = CompaniesHouse.Tests.ResourceBuilders.Officer;
using Officers = CompaniesHouse.Tests.ResourceBuilders.Officers;

namespace CompaniesHouse.Tests.CompaniesHouseOfficersTests
{
    public class OfficersBuilder
    {
        public Officers Build()
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<Officer>(x => x.AppointedOn));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<Officer>(x => x.ResignedOn));

            var officers = EnumerationMappings.PossibleOfficerRoles.Keys.Select(x => fixture.Build<Officer>()
                .With(y => y.OfficerRole, x)
                .With(y => y.Links,
                    new OfficerLinks()
                        {Officer = new OfficerAppointmentLink() {AppointmentsResource = "/officers/xyz/appointments"}})
                .Create()).ToArray();

            var officerSummary = fixture.Build<Officers>().With(x => x.Items, officers).Create();

            var result = fixture.Build<Officers>()
                .With(x => x.Items, officerSummary.Items)
                .With(x => x.ActiveCount, officerSummary.ActiveCount)
                .With(x => x.ResignedCount, officerSummary.ResignedCount)
                .Create();

            return result;
        }
    }
}

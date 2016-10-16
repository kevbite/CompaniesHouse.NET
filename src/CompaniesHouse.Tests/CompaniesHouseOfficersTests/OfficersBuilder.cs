using System;
using System.Linq;
using CompaniesHouse.Tests.ResourceBuilders;
using Ploeh.AutoFixture;

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

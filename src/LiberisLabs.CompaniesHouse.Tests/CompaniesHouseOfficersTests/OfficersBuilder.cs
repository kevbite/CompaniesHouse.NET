using System;
using System.Linq;
using LiberisLabs.CompaniesHouse.Response.Officers;
using Ploeh.AutoFixture;

namespace LiberisLabs.CompaniesHouse.Tests.CompaniesHouseOfficersTests
{
    public class OfficersBuilder
    {
        public Officers Build()
        {
            var fixture = new Fixture();

            var officers = EnumerationMappings.PossibleOfficerRoles.Values.Select(x => fixture.Build<Response.CompanyProfile.Officer>()
            .With(y => y.OfficerRole, x)
            .With(y => y.AppointedOn, new DateTime(2000, 01, 01))
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

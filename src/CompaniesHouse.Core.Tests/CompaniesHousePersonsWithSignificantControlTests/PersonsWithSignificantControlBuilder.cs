using Ploeh.AutoFixture;
using PersonWithSignificantControl = CompaniesHouse.Tests.ResourceBuilders.PersonWithSignificantControl;
using PersonsWithSignificantControl = CompaniesHouse.Tests.ResourceBuilders.PersonsWithSignificantControl;
using System.Linq;

namespace CompaniesHouse.Core.Tests.CompaniesHousePersonsWithSignificantControlTests
{
    public class PersonsWithSignificantControlBuilder
    {
        public PersonsWithSignificantControl Build()
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<PersonWithSignificantControl>(x => x.NotifiedOn));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<PersonWithSignificantControl>(x => x.CeasedOn));

            var personsWithSignificantControl = EnumerationMappings.PossiblePersonWithSignificantControlKinds.Values.Select(x => fixture.Build<PersonWithSignificantControl>()
           .With(y => y.Kind, x)
           .With(y => y.Links,
               new Response.PersonsWithSignificantControl.PersonWithSignificantControlLinks()
               { 
                    Self = "/company/01234567/persons-with-significant-control/individual/L2m6DxTJA0pkUNh9SIcJY8_cdWE",
                    Statement = ""
               })
           .Create()).ToArray();


            var personWithSignificantControlSummary = fixture.Build<PersonsWithSignificantControl>().With(x => x.Items, personsWithSignificantControl).Create();

            var result = fixture.Build<PersonsWithSignificantControl>()
                .With(x => x.Items, personWithSignificantControlSummary.Items)
                .With(x => x.ActiveCount, personWithSignificantControlSummary.ActiveCount)
                .With(x => x.CeasedCount, personWithSignificantControlSummary.CeasedCount)
                .Create();

            return result;
        }
    }
}

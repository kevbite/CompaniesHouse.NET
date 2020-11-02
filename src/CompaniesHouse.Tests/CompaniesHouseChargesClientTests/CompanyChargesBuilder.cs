using System.Linq;
using AutoFixture;
using CompaniesHouse.Tests.ResourceBuilders;

namespace CompaniesHouse.Tests.CompaniesHouseChargesClientTests
{
    public class CompanyChargesBuilder
    {
        public static Charges Create(CompaniesHouseChargesClientTestCase testCase)
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<Charge>(x => x.AcquiredOn));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<Charge>(x => x.CreatedOn));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<Charge>(x => x.DeliveredOn));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<Charge>(x => x.CoveringInstrumentDate));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<Charge>(x => x.SatisfiedOn));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<Charge>(x => x.ResolvedOn));
            fixture.Customizations.Add(new UniversalDateSpecimenBuilder<Transaction>(x => x.DeliveredOn));

            var secureDetail = fixture.Build<SecuredDetail>()
                .With(x => x.Type, testCase.SecureDetailType)
                .Create();

            var particular = fixture.Build<Particular>()
                .With(x => x.Type, testCase.ParticularType)
                .Create();
            
            var classification = fixture.Build<Classification>()
                .With(x => x.Type, testCase.ClassificationChargeType)
                .Create();
            
            var items = fixture.Build<Charge>()
                .With(x => x.AssetsCeasedReleased, testCase.AssetsCeasedReleased)
                .With(x => x.Status, testCase.Status)
                .With(x => x.Classification, classification)
                .With(x => x.Particular, particular)
                .With(x => x.SecuredDetail, secureDetail)
                .CreateMany();

            var charges = fixture.Build<Charges>()
                .With(x => x.Items, items.ToArray())
                .Create();

            return charges;
        }
    }
}
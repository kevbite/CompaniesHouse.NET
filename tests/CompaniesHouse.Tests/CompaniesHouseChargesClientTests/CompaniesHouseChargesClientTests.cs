using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Tests.ResourceBuilders;
using CompaniesHouse.UriBuilders;
using Moq;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.CompaniesHouseChargesClientTests
{
    public class CompaniesHouseChargesClientTests
    {
        [Theory]
        [MemberData(nameof(TestCases))]
        public async Task GivenACompaniesHouseChargesClient_WhenGettingCompanyCharges(CompaniesHouseChargesClientTestCase testCase)
        {
            var charges = CompanyChargesBuilder.Create(testCase);
            var resource = new CompanyChargesResourceBuilder(charges).Create();
            var uri = new Uri("https://wibble.com/company/1/charges");
            var handler = new StubHttpMessageHandler(uri, resource);
            var uriBuilder = new Mock<IChargesUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(uri);
            var client = new CompaniesHouseChargesClient(new HttpClient(handler), uriBuilder.Object);

            var result = await client.GetChargesListAsync("1", 0, 25);

            EquivalencyAssertionExtensions.ShouldBeEquivalentTo((object)result.Data, charges, "TransactionId");
            foreach (var (actual, expected) in result.Data.Items.Zip(charges.Items))
            {
                actual.InsolvencyCases.Select(x => x.TransactionId).ShouldBe(expected.InsolvencyCases.Select(x => (long?)x.TransactionId));
            }
        }

        [Theory]
        [MemberData(nameof(TestCases))]
        public async Task GivenACompaniesHouseChargesClient_WhenGettingCompanyChargeById(CompaniesHouseChargesClientTestCase testCase)
        {
            var charge = CompanyChargesBuilder.CreateOne(testCase);
            var resource = CompanyChargesResourceBuilder.CreateOne(charge);
            var uri = new Uri("https://wibble.com/company/1/charges/1");
            var handler = new StubHttpMessageHandler(uri, resource);
            var uriBuilder = new Mock<IChargesUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<string>())).Returns(uri);
            var client = new CompaniesHouseChargesClient(new HttpClient(handler), uriBuilder.Object);

            var result = await client.GetChargeByIdAsync("1", "1");

            EquivalencyAssertionExtensions.ShouldBeEquivalentTo((object)result.Data, charge, "TransactionId");
            result.Data.InsolvencyCases.Select(x => x.TransactionId).ShouldBe(charge.InsolvencyCases.Select(x => (long?)x.TransactionId));
        }
        
        public static IEnumerable<object[]> TestCases()
        {
            var allAssetsCeasedReleased = EnumerationMappings.PossibleAssetsCeasedReleased.Keys.Select(x => new CompaniesHouseChargesClientTestCase
            {
                AssetsCeasedReleased = x,
                ParticularType = EnumerationMappings.PossibleParticularTypes.Keys.First(),
                SecureDetailType = EnumerationMappings.PossibleSecuredDetailTypes.Keys.First(),
                ClassificationChargeType = EnumerationMappings.PossibleClassificationChargeTypes.Keys.First(),
                Status = EnumerationMappings.PossibleChargeStatuses.Keys.First()
            });

            var allParticularTypes = EnumerationMappings.PossibleParticularTypes.Keys.Select(x => new CompaniesHouseChargesClientTestCase
            {
                AssetsCeasedReleased = EnumerationMappings.PossibleAssetsCeasedReleased.Keys.First(),
                ParticularType = x,
                SecureDetailType = EnumerationMappings.PossibleSecuredDetailTypes.Keys.First(),
                ClassificationChargeType = EnumerationMappings.PossibleClassificationChargeTypes.Keys.First(),
                Status = EnumerationMappings.PossibleChargeStatuses.Keys.First()
            });

            var allSecuredDetailTypes = EnumerationMappings.PossibleSecuredDetailTypes.Keys.Select(x => new CompaniesHouseChargesClientTestCase
            {
                AssetsCeasedReleased = EnumerationMappings.PossibleAssetsCeasedReleased.Keys.First(),
                ParticularType = EnumerationMappings.PossibleParticularTypes.Keys.First(),
                SecureDetailType = x,
                ClassificationChargeType = EnumerationMappings.PossibleClassificationChargeTypes.Keys.First(),
                Status = EnumerationMappings.PossibleChargeStatuses.Keys.First()
            });

            var allClassificationChargeTypes = EnumerationMappings.PossibleClassificationChargeTypes.Keys.Select(x => new CompaniesHouseChargesClientTestCase
            {
                AssetsCeasedReleased = EnumerationMappings.PossibleAssetsCeasedReleased.Keys.First(),
                ParticularType = EnumerationMappings.PossibleParticularTypes.Keys.First(),
                SecureDetailType = EnumerationMappings.PossibleSecuredDetailTypes.Keys.First(),
                ClassificationChargeType = x,
                Status = EnumerationMappings.PossibleChargeStatuses.Keys.First()
            });
            
            var allChargeStatuses = EnumerationMappings.PossibleChargeStatuses.Keys.Select(x => new CompaniesHouseChargesClientTestCase
            {
                AssetsCeasedReleased = EnumerationMappings.PossibleAssetsCeasedReleased.Keys.First(),
                ParticularType = EnumerationMappings.PossibleParticularTypes.Keys.First(),
                SecureDetailType = EnumerationMappings.PossibleSecuredDetailTypes.Keys.First(),
                ClassificationChargeType = EnumerationMappings.PossibleClassificationChargeTypes.Keys.First(),
                Status = x
            });

            return allAssetsCeasedReleased
                .Concat(allParticularTypes)
                .Concat(allSecuredDetailTypes)
                .Concat(allClassificationChargeTypes)
                .Concat(allChargeStatuses)
                .Select(testCase => new object[] { testCase });
        }
    }
}
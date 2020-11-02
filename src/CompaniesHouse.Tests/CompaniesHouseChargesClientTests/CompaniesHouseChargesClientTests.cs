using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Tests.ResourceBuilders;
using CompaniesHouse.UriBuilders;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace CompaniesHouse.Tests.CompaniesHouseChargesClientTests
{
    [TestFixture]
    public class CompaniesHouseChargesClientTests
    {
        [TestCaseSource(nameof(TestCases))]
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

            result.Data.ShouldBeEquivalentTo(charges);
        }

        private static CompaniesHouseChargesClientTestCase[] TestCases()
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
                .ToArray();
        }
    }
}
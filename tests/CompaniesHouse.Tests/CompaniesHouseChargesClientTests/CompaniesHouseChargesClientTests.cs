using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Response;
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

            EquivalencyAssertionExtensions.ShouldBeEquivalentTo((object)result.Data, charges, "TransactionId", "UnfilteredCount");
            foreach (var (actual, expected) in (result.Data.Items ?? []).Zip(charges.Items ?? []))
            {
                (actual.InsolvencyCases ?? []).Select(x => x.TransactionId)
                    .ShouldBe((expected.InsolvencyCases ?? []).Select(x => (long?)x.TransactionId));
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
            (result.Data.InsolvencyCases ?? []).Select(x => x.TransactionId)
                .ShouldBe((charge.InsolvencyCases ?? []).Select(x => (long?)x.TransactionId));
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

        [Fact]
        public async Task GivenARealCapturedChargeList_WhenGettingCompanyCharges_ThenUnfilteredCountAndChargeFieldsDeserialize()
        {
            const string json = """
                {
                  "etag":"96a8b4fffcc72586b0b003550132128341cdc4f5",
                  "total_count":1,
                  "unfiltered_count":1,
                  "satisfied_count":0,
                  "part_satisfied_count":0,
                  "items":[
                    {
                      "etag":"43a456b9b17fc077d7ef8a9861b9842a20e7eba5",
                      "classification":{"type":"charge-description","description":"Rent deposit deed"},
                      "charge_number":1,
                      "status":"outstanding",
                      "delivered_on":"2012-10-02",
                      "created_on":"2012-09-25",
                      "particulars":{"type":"short-particulars","description":"£18,930.87 together with all interest accrued thereto."},
                      "secured_details":{"type":"amount-secured","description":"£18,930.87 due or to become due from the company to the chargee under the terms of the aforementioned instrument creating or evidencing the charge"},
                      "persons_entitled":[{"name":"Lazari Investments Limited"}],
                      "transactions":[{"filing_type":"create-charge-pre-april-2013","delivered_on":"2012-10-02","links":{"filing":"/company/03977902/filing-history/MzA2NTI5MDU2N2FkaXF6a2N4"}}],
                      "links":{"self":"/company/03977902/charges/4VMbVfCBWdzCW2fXOF5QTezbJ9g"}
                    }
                  ]
                }
                """;

            var uri = new Uri("https://wibble.com/company/03977902/charges");
            var handler = new StubHttpMessageHandler(uri, json);
            var uriBuilder = new Mock<IChargesUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(uri);

            var client = new CompaniesHouseChargesClient(new HttpClient(handler), uriBuilder.Object);
            var result = await client.GetChargesListAsync("03977902", 0, 25);

            result.Data.ShouldNotBeNull();
            result.Data.UnfilteredCount.ShouldBe(1);
            result.Data.Items.ShouldNotBeNull();
            result.Data.Items[0].Status.ShouldBe(new ChargeStatus("outstanding"));
            result.Data.Items[0].Classification?.Type.ShouldBe(new ClassificationChargeType("charge-description"));
            result.Data.Items[0].Particular?.Type.ShouldBe(new ParticularType("short-particulars"));
            result.Data.Items[0].SecuredDetail?.Type.ShouldBe(new SecuredDetailType("amount-secured"));
        }
    }
}
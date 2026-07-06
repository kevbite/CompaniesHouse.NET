using System;
using System.Text.Json;
using CompaniesHouse.Response;
using CompaniesHouse.Response.Charges;
using CompaniesHouse.Response.CompanyFiling;
using Shouldly;
using Xunit;

namespace CompaniesHouse.ScenarioTests
{
    public class FilingAndChargesScenarios
    {
        [Fact]
        public void FilingHistoryItem_DeserializesSingleSubcategoryAndDocumentLink()
        {
            const string json = """
                {
                  "transaction_id":"MzUyMDQ1NzU4MWFkaXF6a2N4",
                  "barcode":"XF1MYMJM",
                  "type":"MR01",
                  "date":"2026-05-08",
                  "category":"mortgage",
                  "subcategory":"create",
                  "description":"mortgage-create-with-deed-with-charge-number-charge-creation-date",
                  "description_values":{"charge_number":"000020650090","charge_creation_date":"2026-05-06"},
                  "pages":16,
                  "action_date":"2026-05-06",
                  "links":{"self":"/company/00002065/filing-history/MzUyMDQ1NzU4MWFkaXF6a2N4","document_metadata":"https://document-api.company-information.service.gov.uk/document/yiC6UOsmY5UnJERjCxHDRMUIKbFEY_R5zcSTVyVLT-A"}
                }
                """;

            var value = JsonSerializer.Deserialize<FilingHistoryItem>(json, CompaniesHouseJsonSerializerOptions.Default);

            value.ShouldNotBeNull();
            value.Category.ShouldBe(new FilingCategory("mortgage"));
            value.Subcategory.ShouldBe([new FilingSubcategory("create")]);
            value.ActionDate.ShouldBe(new DateTime(2026, 05, 06));
        }

        [Fact]
        public void CompanyCharges_DeserializesUnfilteredCountAndGeneratedValueTypes()
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
                      "particulars":{"type":"short-particulars","description":"£18,930.87"},
                      "secured_details":{"type":"amount-secured","description":"£18,930.87 due"},
                      "links":{"self":"/company/03977902/charges/4VMbVfCBWdzCW2fXOF5QTezbJ9g"}
                    }
                  ]
                }
                """;

            var value = JsonSerializer.Deserialize<Charges>(json, CompaniesHouseJsonSerializerOptions.Default);
            var items = value?.Items ?? [];

            value.ShouldNotBeNull();
            value.UnfilteredCount.ShouldBe(1);
            items.ShouldNotBeEmpty();
            items[0].Status.ShouldBe(new ChargeStatus("outstanding"));
            items[0].Classification?.Type.ShouldBe(new ClassificationChargeType("charge-description"));
        }
    }
}

using System.Linq;

namespace CompaniesHouse.Core.Tests.CompaniesHouseDocumentMetadataClientTests
{
    public class DocumentMetadataResourceBuilder
    {
        private readonly DocumentMetadataTestCase _documentMetadataTestCase;

        public DocumentMetadataResourceBuilder(DocumentMetadataTestCase documentMetadataTestCase)
        {
            _documentMetadataTestCase = documentMetadataTestCase;
        }

        public string Create()
        {
            return $@"{{
    ""company_number"": ""{_documentMetadataTestCase.CompanyNumber}"",
    ""barcode"": ""{_documentMetadataTestCase.Barcode}"",
    ""significant_date"": ""{_documentMetadataTestCase.SignificantDate:O}"",
    ""significant_date_type"": ""{_documentMetadataTestCase.SignificantDateType}"",
    ""category"": ""{_documentMetadataTestCase.Category}"",
    ""pages"": {_documentMetadataTestCase.Pages},
    ""created_at"": ""{_documentMetadataTestCase.CreatedAt:O}"",
    ""etag"": ""{_documentMetadataTestCase.Etag}"",
    ""links"": {{
        ""self"": ""{_documentMetadataTestCase.Links.Self}"",
        ""document"": ""{_documentMetadataTestCase.Links.Document}""
    }},
    ""resources"": {{ {GetResources(_documentMetadataTestCase)} }}
}}";


            string GetResources(DocumentMetadataTestCase testCase) => string.Join(",",
                testCase.Resources.Select(x => $@"""{x.Key}"": {{""content_length"": {x.Value.ContentLength}}}"));
        }
    }
}
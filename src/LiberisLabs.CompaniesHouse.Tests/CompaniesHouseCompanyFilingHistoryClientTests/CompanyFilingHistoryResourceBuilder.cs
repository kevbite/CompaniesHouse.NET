using System.Linq;
using LiberisLabs.CompaniesHouse.Tests.ResourceBuilders;

namespace LiberisLabs.CompaniesHouse.Tests.CompaniesHouseCompanyFilingHistoryClientTests
{
    public class CompanyFilingHistoryResourceBuilder
    {
        private readonly CompanyFilingHistory _companyFilingHistory;

        public CompanyFilingHistoryResourceBuilder(CompanyFilingHistory companyFilingHistory)
        {
            _companyFilingHistory = companyFilingHistory;
        }

        public string Create()
        {
            return $@"{{
                       ""etag"" : ""{_companyFilingHistory.ETag}"",
                       ""filing_history_status"" : ""{_companyFilingHistory.HistoryStatus}"",
                       ""items"" : [
                           {string.Join(",", _companyFilingHistory.Items.Select(GetItemJsonBlock))}
                       ],
                       ""items_per_page"" : ""{_companyFilingHistory.ItemsPerPage}"",
                       ""kind"" : ""{_companyFilingHistory.Kind}"",
                       ""start_index"" : ""{_companyFilingHistory.StartIndex}"",
                       ""total_count"" : ""{_companyFilingHistory.TotalCount}""
                    }}";
        }

        private string GetItemJsonBlock(FilingHistoryItem item)
        {
            return $@"{{
                         ""annotations"" : [
                           {string.Join(",", item.Annotations.Select(GetAnnotationJsonBlock))}
                         ],
                         ""associated_filings"" : [
                           {string.Join(",", item.AssociatedFilings.Select(GetAssociatedFilingJsonBlock))}
                         ],
                         ""barcode"" : ""{item.Barcode}"",
                         ""category"" : ""{item.Category}"",
                         ""date"" : ""{item.DateOfProcessing.ToString("yyyy-MM-dd")}"",
                         ""description"" : ""{item.Description}"",
                         ""links"" : {{
                            ""document_metadata"" : ""{item.Links.DocumentMetaData}"",
                            ""self"" : ""{item.Links.Self}""
                         }},
                         ""pages"" : ""{item.PageCount}"",
                         ""paper_filed"" : ""{item.PaperFiled}"",
                         ""resolutions"" : [
                           {string.Join(",", item.Resolutions.Select(GetResolutionJsonBlock))}
                         ],
                         ""subcategory"" : ""{item.Subcategory}"",
                         ""transaction_id"" : ""{item.TransactionId}"",
                         ""type"" : ""{item.FilingType}""
                      }}";
        }

        private string GetAnnotationJsonBlock(FilingHistoryItemAnnotation annotation)
        {
            return $@"{{
                         ""annotation"" : ""{annotation.Annotation}"",
                         ""date"" : ""{annotation.DateOfAnnotation.ToString("yyyy-MM-dd")}"",
                         ""description"" : ""{annotation.Description}""
                      }}";
        }

        private string GetAssociatedFilingJsonBlock(FilingHistoryItemAssociatedFiling associated)
        {
            return $@"{{
                         ""date"" : ""{associated.Date.ToString("yyyy-MM-dd")}"",
                         ""description"" : ""{associated.Description}"",
                         ""type"" : ""{associated.FilingType}""
                      }}";
        }

        private string GetResolutionJsonBlock(FilingHistoryItemResolution resolution)
        {
            return $@"{{
                         ""category"" : ""{resolution.Category}"",
                         ""description"" : ""{resolution.Description}"",
                         ""document_id"" : ""{resolution.DocumentId}"",
                         ""receive_date"" : ""{resolution.DateOfProcessing.ToString("yyyy-MM-dd")}"",
                         ""subcategory"" : ""{resolution.Subcategory}"",
                         ""type"" : ""{resolution.ResolutionType}""
                      }}";
        }


    }
}

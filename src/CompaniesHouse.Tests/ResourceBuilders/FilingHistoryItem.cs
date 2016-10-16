using System;
using System.Collections.Generic;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class FilingHistoryItem
    {
        public string Category { get; set; }

        public string Subcategory { get; set; }

        public string TransactionId { get; set; }

        public string FilingType { get; set; }

        public string Barcode { get; set; }

        public DateTime DateOfProcessing { get; set; }

        public string Description { get; set; }

        public Dictionary<string, string> DescriptionValues { get; set; }

        public int PageCount { get; set; }

        public bool PaperFiled { get; set; }

        public FilingHistoryItemAnnotation[] Annotations { get; set; }

        public FilingHistoryItemAssociatedFiling[] AssociatedFilings { get; set; }

        public FilingHistoryItemResolution[] Resolutions { get; set; }

        public CompanyFillingLinks Links { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class FilingHistoryItem
    {
        public string Category { get; set; } = null!;

        public string Subcategory { get; set; } = null!;

        public string TransactionId { get; set; } = null!;

        public string FilingType { get; set; } = null!;

        public string Barcode { get; set; } = null!;

        public DateTime DateOfProcessing { get; set; }

        public string Description { get; set; } = null!;

        public Dictionary<string, string> DescriptionValues { get; set; } = null!;

        public int PageCount { get; set; }

        public bool PaperFiled { get; set; }

        public FilingHistoryItemAnnotation[] Annotations { get; set; } = null!;

        public FilingHistoryItemAssociatedFiling[] AssociatedFilings { get; set; } = null!;

        public FilingHistoryItemResolution[] Resolutions { get; set; } = null!;

        public CompanyFillingLinks Links { get; set; } = null!;
    }
}

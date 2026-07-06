using System;
using System.Collections.Generic;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class FilingHistoryItemResolution
    {
        public string Category { get; set; } = null!;

        public string Subcategory { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string DocumentId { get; set; } = null!;

        public DateTime DateOfProcessing { get; set; }

        public string ResolutionType { get; set; } = null!;

        public Dictionary<string, string> DescriptionValues { get; set; } = null!;
    }
}

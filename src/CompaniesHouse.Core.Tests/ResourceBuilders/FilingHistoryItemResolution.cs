using System;
using System.Collections.Generic;

namespace CompaniesHouse.Core.Tests.ResourceBuilders
{
    public class FilingHistoryItemResolution
    {
        public string Category { get; set; }

        public string Subcategory { get; set; }

        public string Description { get; set; }

        public string DocumentId { get; set; }

        public DateTime DateOfProcessing { get; set; }

        public string ResolutionType { get; set; }

        public Dictionary<string, string> DescriptionValues { get; set; }
    }
}

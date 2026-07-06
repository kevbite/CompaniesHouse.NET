using System;
using System.Collections.Generic;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class FilingHistoryItemAssociatedFiling
    {
        public string FilingType { get; set; } = null!;

        public DateTime Date { get; set; }

        public string Description { get; set; } = null!;

        public Dictionary<string, string> DescriptionValues { get; set; } = null!;
    }
}
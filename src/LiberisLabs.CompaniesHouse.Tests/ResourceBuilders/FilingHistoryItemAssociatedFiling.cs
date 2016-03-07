using System;
using System.Collections.Generic;

namespace LiberisLabs.CompaniesHouse.Tests.ResourceBuilders
{
    public class FilingHistoryItemAssociatedFiling
    {
        public string FilingType { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public Dictionary<string, string> DescriptionValues { get; set; }
    }
}
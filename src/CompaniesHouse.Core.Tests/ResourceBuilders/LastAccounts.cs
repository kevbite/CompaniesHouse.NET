using System;

namespace CompaniesHouse.Core.Tests.ResourceBuilders
{
    public class LastAccounts
    {
        public string Type { get; set; }

        public DateTime MadeUpTo { get; set; }

        public DateTime? PeriodEndOn { get; set; }

        public DateTime? PeriodStartOn { get; set; }
    }
}
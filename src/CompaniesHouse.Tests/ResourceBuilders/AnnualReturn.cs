using System;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class AnnualReturn
    {
        public bool Overdue { get; set; }

        public DateTime NextMadeUpTo { get; set; }

        public DateTime LastMadeUpTo { get; set; }

        public DateTime NextDue { get; set; }
    }
}
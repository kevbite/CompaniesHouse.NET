using System;

namespace LiberisLabs.CompaniesHouse.Tests.ResourceBuilders
{
    public class ConfirmationStatement
    {
        public DateTime? LastMadeUpTo { get; set; }

        public DateTime? NextDue { get; set; }

        public DateTime? NextMadeUpTo { get; set; }
        
        public bool? Overdue { get; set; }
    }
}
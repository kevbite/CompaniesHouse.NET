using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompaniesHouse.Core.Tests.ResourceBuilders
{
    public class NextAccounts
    {
        public DateTime? DueOn { get; set; }

        public bool? Overdue { get; set; }

        public DateTime? PeriodEndOn { get; set; }

        public DateTime? PeriodStartOn { get; set; }
    }
}

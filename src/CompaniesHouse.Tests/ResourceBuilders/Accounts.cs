using System;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class Accounts
    {
        public DateTime NextDue { get; set; }

        public AccountingReferenceDate AccountingReferenceDate { get; set; }

        public LastAccounts LastAccounts { get; set; }

        public DateTime NextMadeUpTo { get; set; }

        public bool Overdue { get; set; }
    }
}
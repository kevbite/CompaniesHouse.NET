namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class OfficerSummary
    {
        public int ActiveCount { get; set; }

        public Officer[] Officers { get; set; } = null!;

        public int ResignedCount { get; set; }
    }
}
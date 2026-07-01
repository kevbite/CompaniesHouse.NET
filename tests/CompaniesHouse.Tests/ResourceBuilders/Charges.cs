namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class Charges
    {
        public string? Etag { get; set; }

        public Charge[]? Items { get; set; }

        public int? PartSatisfiedCount { get; set; }

        public int? SatisfiedCount { get; set; }

        public int? TotalCount { get; set; }

        public int? UnfileteredCount { get; set; }
    }
}

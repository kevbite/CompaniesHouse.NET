namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class PersonsWithSignificantControl
    {
        public int? ActiveCount { get; set; }

        public PersonWithSignificantControl[] Items { get; set; } = null!;

        public int? CeasedCount { get; set; }
    }
}
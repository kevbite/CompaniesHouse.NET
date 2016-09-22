namespace LiberisLabs.CompaniesHouse.Tests.ResourceBuilders.OfficerSearchResource
{
    public class Item
    {
        public string Description { get; set; }

        public string Snippet { get; set; }

        public DateOfBirth DateOfBirth { get; set; }

        public string AddressSnippet { get; set; }

        public Address Address { get; set; }

        public string[] DescriptionIdentifiers { get; set; }

        public int AppointmentCount { get; set; }

        public Links Links { get; set; }

        public string Title { get; set; }

        public string Kind { get; set; }

        public Matches Matches { get; set; }
    }
}
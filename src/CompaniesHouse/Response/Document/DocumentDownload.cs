using System.IO;

namespace CompaniesHouse.Response.Document
{
    public class DocumentDownload
    {
        public Stream Content { get; set; } = null!;
        public string ContentType { get; set; } = null!;
        public long? ContentLength { get; set; }
    }
}

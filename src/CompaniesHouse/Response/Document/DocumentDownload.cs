using System.IO;

namespace CompaniesHouse.Response.Document
{
    public class DocumentDownload
    {
        public Stream Content { get; set; }
        public string ContentType { get; set; }
        public long? ContentLength { get; set; }
    }
}
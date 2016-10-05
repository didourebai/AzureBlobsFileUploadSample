namespace AzureBlobsFileUploadSample.WebAPI.Models
{
    public class FileDetails
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public string ContentType { get; set; }
        public string Location { get; set; }
    }
}
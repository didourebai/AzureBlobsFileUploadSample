using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AzureBlobsFileUploadSample.WebAPI.Helpers;
using AzureBlobsFileUploadSample.WebAPI.Models;
using Microsoft.WindowsAzure.StorageClient;

namespace AzureBlobsFileUploadSample.WebAPI.Controllers
{
    [RoutePrefix("api/upload")]
    public class FilesController : ApiController
    {

     [HttpPost, Route("")]
        public Task<List<FileDetails>> Post()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var multipartStreamProvider = new AzureBlobStorageMultipartProvider(BlobHelper.GetWebApiContainer());
            return Request.Content.ReadAsMultipartAsync<AzureBlobStorageMultipartProvider>(multipartStreamProvider).ContinueWith<List<FileDetails>>(t =>
            {
                if (t.IsFaulted)
                {
                    throw t.Exception;
                }

                AzureBlobStorageMultipartProvider provider = t.Result;
                return provider.Files;
            });
        }

        public IEnumerable<FileDetails> Get()
        {
            CloudBlobContainer container = BlobHelper.GetWebApiContainer();
            foreach (CloudBlockBlob blob in container.ListBlobs())
            {
                yield return new FileDetails
                {
                    Name = blob.Name,
                    Size = blob.Properties.Length,
                    ContentType = blob.Properties.ContentType,
                    Location = blob.Uri.AbsoluteUri
                };
            }
        }
    }

   
}
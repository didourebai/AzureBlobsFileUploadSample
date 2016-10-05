﻿using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace AzureBlobsFileUploadSample.WebAPI.Helpers
{
    internal static class BlobHelper
    {
        public static CloudBlobContainer GetWebApiContainer()
        {
           
            // Retrieve storage account from connection-string
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=allotabibstorage;AccountKey=XsUuwCI2Ba8y8WnIfxjlhVGgW+ylhrjlezt9OgG1Koqs97iOOvL09Ru10L12D+Q9yNRlY1EkuxD0DejO6GBgOQ==");

            // Create the blob client 
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container 
            // Container name must use lower case
            CloudBlobContainer container = blobClient.GetContainerReference("webapicontainer");

            // Create the container if it doesn't already exist
            container.CreateIfNotExist();

            // Enable public access to blob
            var permissions = container.GetPermissions();
            if (permissions.PublicAccess == BlobContainerPublicAccessType.Off)
            {
                permissions.PublicAccess = BlobContainerPublicAccessType.Blob;
                container.SetPermissions(permissions);
            }

            return container;
        }
    }
}
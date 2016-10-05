# AzureBlobsFileUploadSample
Azure Blob storage is a service that stores unstructured data in the cloud as objects/blobs. Blob storage can store any type of text or binary data, such as a document, media file, or application installer. Blob storage is also referred to as object storage.
#Overview

Azure Blob Storage is part of the Microsoft Azure Storage service that is able to  stores unstructured data in the cloud as objects/blobs. 
Blob storage s a collection of binary data can store any type like :  text , binary data, such as a document, media file, or application installer as a single entity.
Prerequisites:

Microsoft Visual Studio (http://www.visualstudio.com/en-us/visual-studio-homepage-vs.aspx)
Azure Storage Client Library for .NET (http://www.nuget.org/packages/WindowsAzure.Storage)
Azure Configuration Manager for .NET (http://www.nuget.org/packages/Microsoft.WindowsAzure.ConfigurationManager)
An Azure storage account (you can benefit from free 3 months https://www.microsoft.com/itprocloudessentials/en-US?utm_content=buffer0fc26&utm_medium=social&utm_source=linkedin.com&utm_campaign=buffer) 
  
  ---- We recommend to use the last version of the Azure Storage Client Library for .NET  -----
  
#Blob service concepts
For more detail : https://msdn.microsoft.com/library/azure/dd135715.aspx
1- Create a storage account in Microsoft Azure

From Preview Portal, select New > Data and Storage > Storage Account
Then you put the name, the resource group and the location of your storage account.
After a few minutes your storage account will be pinned in the dashboard and ready to use!
2- Create a container to store your files

In order to store your files in Azure Blob Storage, you need to have to start by adding a container, which groups any set of blobs. A container can have two different access types:

Private, which does not provide anonymous access to the container or the blobs therein.
Public, in which case all the blobs within the container can be accessed publicly through anonymous access; however, in order to list all blobs in a container, the account credentials are necessary.
So, let’s name the container in our example “images” and set its access type to Public.
for more details : https://azure.microsoft.com/en-us/documentation/articles/storage-manage-access-to-resources/

3- Storage Account Credentials
4- Set up your development environment

Now we will create a project type : Asp.net MVC after we select Web API template. ASP.NET 4.6 Templates and we leave Authentication to “No Authentication”.

Enable nuget packages.
Use NuGet to install the required packages: There are two packages that you'll need to install to your project:

Microsoft Azure Storage Client Library for .NET: This package provides programmatic access to data resources in your storage account.

Microsoft Azure Configuration Manager library for .NET: This package provides a class for parsing a connection string from a configuration file, regardless of where your application is running.

5- Configure your storage connection string


6- Let's go to our Web API application 

Create a Custom Stream Provider
We need to extend MultipartFormDataStreamProvider class by creating your own AzureStorageMultipartFormDataStreamProvider, which will be responsible for writing streamed data directly to a blob in your container.


We will create BlobHelper and FileDetails  :



Now, we  add an Upload Api Controller :

Finally, you need to create an Api Controller, which will provide the API for the file to be uploaded in your storage account.


Now, we will test our Web API using POSTMAN.

All successfully uploaded images will be available in 'directory name' container, in Azure Preview Portal.

Github : https://github.com/didourebai/AzureBlobsFileUploadSample ( Test and comment please ...).

More samples

For additional examples using Blob storage, see Getting Started with Azure Blob Storage in .NET. 




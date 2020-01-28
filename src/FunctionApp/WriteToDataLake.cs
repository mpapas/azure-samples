using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Azure.Storage;
using Azure.Storage.Files.DataLake;

namespace FunctionApp
{
    public static class WriteToDataLake
    {
        [FunctionName("WriteToDataLake")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            //connect to account
            string accountName = Common.GetEnvironmentVariable("DataLakeAccountName");
            string accountKey = Common.GetEnvironmentVariable("DataLakeAccountKey");
            string fileSystemName = Common.GetEnvironmentVariable("DataLakeFileSystemName");

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(accountName, accountKey);

            string dfsUri = "https://" + accountName + ".dfs.core.windows.net";

            DataLakeServiceClient dataLakeServiceClient = new DataLakeServiceClient(new Uri(dfsUri), sharedKeyCredential);

            //upload file
            DataLakeFileSystemClient fileSystemClient = dataLakeServiceClient.GetFileSystemClient(fileSystemName);

            string fileName = Guid.NewGuid().ToString() + ".json";
            DataLakeFileClient fileClient = await fileSystemClient.CreateFileAsync(fileName);

            long fileSize = req.Body.Length;

            await fileClient.AppendAsync(req.Body, offset: 0);

            await fileClient.FlushAsync(position: fileSize);

            return (ActionResult)new OkResult();
        }
    }
}

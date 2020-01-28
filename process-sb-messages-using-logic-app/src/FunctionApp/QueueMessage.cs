using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Model;

namespace FunctionApp
{
    public static class QueueMessage
    {
        [FunctionName("QueueMessage")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [ServiceBus("inqueue")]IAsyncCollector<string> outputSbQueue,
            ILogger log)
        {
            // Create a new message to send to the queue.
            var myMessage = new MyMessage
            {
                Id = Guid.NewGuid(),
                Description = "New message",
                CreatedDate = DateTime.UtcNow
            };

            string serializedMessage = JsonConvert.SerializeObject(myMessage);

            log.LogInformation(serializedMessage);

            //var message = new Message(Encoding.UTF8.GetBytes(serializedMessage));
            //no need to byte encode
            await outputSbQueue.AddAsync(serializedMessage);

            return (ActionResult)new OkResult();
        }
    }
}

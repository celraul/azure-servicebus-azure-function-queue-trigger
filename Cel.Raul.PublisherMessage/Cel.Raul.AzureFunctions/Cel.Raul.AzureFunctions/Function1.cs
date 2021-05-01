using Cel.Raul.AzureFunctions.Infrastrocture;
using Cel.Raul.AzureQueue.Interfaces;
using Cel.Raul.AzureQueue.Messages;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cel.Raul.AzureFunctions
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([ServiceBusTrigger("celraul-contatos")] string myQueueItem, ILogger log)  // Message
        {

			try
			{
				var queueCommunicator = DependencyInjectionIContainer.Instance.GetService<IQueueCommunicator>();
				var command = queueCommunicator.Read<SendEmailCommand>(myQueueItem);
				// Send e-mail
			}
			catch (Exception ex)
			{
				log.LogError(ex, $"Error {myQueueItem}");
				throw;
			}

			log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}

using Azure.Messaging.ServiceBus;

namespace Cel.Raul.AzureQueue.Interfaces
{
    public interface ICloudQueueClientFactory
	{
		ServiceBusClient GetClient();
	}
}

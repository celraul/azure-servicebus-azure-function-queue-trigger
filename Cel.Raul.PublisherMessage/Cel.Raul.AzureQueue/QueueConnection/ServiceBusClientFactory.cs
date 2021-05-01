using Cel.Raul.AzureQueue.Interfaces;
using Cel.Raul.AzureQueue.Infrastructure;
using Azure.Messaging.ServiceBus;

namespace Cel.Raul.AzureQueue.QueueConnection
{
    public class ServiceBusClientFactory : ICloudQueueClientFactory
    {
        private readonly QueueConfig _queueConfig;
        private ServiceBusClient _cloudQueueClient;

        public ServiceBusClientFactory(QueueConfig queueConfig)
        {
            _queueConfig = queueConfig;
        }

        public ServiceBusClient GetClient()
        {
            if (_cloudQueueClient != null)
                return _cloudQueueClient;

            _cloudQueueClient = new ServiceBusClient(_queueConfig.QueueConnectionString);

            return _cloudQueueClient;
        }
    }
}

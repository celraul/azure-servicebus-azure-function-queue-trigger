using Azure.Messaging.ServiceBus;
using Cel.Raul.AzureQueue.Interfaces;
using Cel.Raul.AzureQueue.Messages;
using Cel.Raul.CrossCutting.MessageSerializer;
using System.Threading.Tasks;

namespace Cel.Raul.AzureQueue.QueueConnection
{
    public class QueueCommunicator : IQueueCommunicator
    {
        private readonly IMessageSerializer _messageSerializer;
        private readonly ICloudQueueClientFactory _cloudQueueClientFactory;

        public QueueCommunicator(IMessageSerializer messageSerializer,
            ICloudQueueClientFactory cloudQueueClientFactory)
        {
            _messageSerializer = messageSerializer;
            _cloudQueueClientFactory = cloudQueueClientFactory;
        }

        public T Read<T>(string message)
        {
            return _messageSerializer.Deserialize<T>(message);
        }

        public async Task SendAsync<T>(T obj) where T : BaseQueueMessage
        {
            var client = _cloudQueueClientFactory.GetClient();

            // create a sender for the queue 
            ServiceBusSender sender = client.CreateSender(obj.QueueName);

            ServiceBusMessage message = new ServiceBusMessage(_messageSerializer.Serialize(obj));
            await sender.SendMessageAsync(message);
        }
    }
}

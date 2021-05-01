namespace Cel.Raul.AzureQueue.Messages
{
    public abstract class BaseQueueMessage
	{
		public string QueueName { get; set; }

		public BaseQueueMessage(string name)
		{
			QueueName = name;
		}
	}
}

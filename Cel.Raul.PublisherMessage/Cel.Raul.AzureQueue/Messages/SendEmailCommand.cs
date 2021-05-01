using Cel.Raul.AzureQueue.Infrastructure;

namespace Cel.Raul.AzureQueue.Messages
{
    public class SendEmailCommand : BaseQueueMessage
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public SendEmailCommand()
            : base(QueueNames.QUEUE_SEND_EMAILS)
        {
        }
    }
}

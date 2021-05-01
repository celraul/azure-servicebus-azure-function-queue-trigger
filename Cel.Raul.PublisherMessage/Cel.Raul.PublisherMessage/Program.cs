using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace Cel.Raul.PublisherMessage
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var connectionString = ConfigurationManager.AppSettings["Azure:ServiceBus"];

            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                // create a sender for the queue 
                ServiceBusSender sender = client.CreateSender(ConfigurationManager.AppSettings["Azure:QueueContatos"]);

                //// create a message that we can send
                string data = JsonConvert.SerializeObject(new { name = "Raul 2" });
                ServiceBusMessage message = new ServiceBusMessage(data);

                //// send the message
                await sender.SendMessageAsync(message);

                Console.WriteLine("Message sent!");
                Console.ReadKey();
            }
        }
    }
}

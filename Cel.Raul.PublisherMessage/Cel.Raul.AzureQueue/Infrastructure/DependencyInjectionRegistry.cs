using Cel.Raul.AzureQueue.Interfaces;
using Cel.Raul.AzureQueue.QueueConnection;
using Cel.Raul.CrossCutting.MessageSerializer;
using Microsoft.Extensions.DependencyInjection;

namespace Cel.Raul.AzureQueue.Infrastructure
{
    public static class DependencyInjectionRegistry
	{
		public static IServiceCollection AddAzureQueueLibrary(this IServiceCollection services, string queueConnectionString)
		{
			services.AddSingleton(new QueueConfig(queueConnectionString));
			services.AddSingleton<ICloudQueueClientFactory, ServiceBusClientFactory>();
			services.AddSingleton<IMessageSerializer, JsonMessageSerializer>();
			services.AddTransient<IQueueCommunicator, QueueCommunicator>();

			return services;
		}
	}
}

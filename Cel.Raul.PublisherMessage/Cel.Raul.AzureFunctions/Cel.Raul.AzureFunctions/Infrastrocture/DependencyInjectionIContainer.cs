using Cel.Raul.AzureQueue.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Cel.Raul.AzureFunctions.Infrastrocture
{
    public class DependencyInjectionIContainer
    {
        private static readonly IServiceProvider _instance = Build();
        public static IServiceProvider Instance => _instance;

        static DependencyInjectionIContainer()
        { }

        private DependencyInjectionIContainer()
        { }

        private static IServiceProvider Build()
        {
            var services = new ServiceCollection();
            
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            services.AddAzureQueueLibrary(configuration["Azure:ServiceBus"]);

            return services.BuildServiceProvider();
        }
    }
}

using Cel.Raul.Application.Services;
using Cel.Raul.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cel.Raul.Application.Extensions
{
    public static class DependencyInjectionServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationDependency(this IServiceCollection services)
        {
            Singleton(services);
            Scope(services);
            Transient(services);

            return services;
        }

        private static void Scope(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        private static void Singleton(IServiceCollection services)
        {
        }

        private static void Transient(IServiceCollection services)
        {
        }
    }
}

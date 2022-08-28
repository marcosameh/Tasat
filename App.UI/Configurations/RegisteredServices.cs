using App.UI.InfraStructure;
using AppCore;
using Microsoft.Extensions.DependencyInjection;

namespace App.UI.Configurations
{
    public static class RegisteredServices
    {
        public static IServiceCollection AddRegisteredServices(this IServiceCollection services)
        {
            services.AddAppCoreServices();
            services.AddSingleton<ResourceInfo>();
            return services;

        }

    }
}

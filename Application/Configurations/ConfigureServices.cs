using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations
{
    public static class ConfigureServices
    {
        public static void ConfigureServicesCollection(IServiceCollection services)
        {
            services.AddSingleton<ICalculateServices, CalculateServices>();
        }
    }
}

using ApiManagers;
using ApiModels.Interfaces.Managers;
using ApiModels.Interfaces.Repositories;
using ApiRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace PisciApi.Ioc
{
    public class AppMappings
    {
        public static void MapDependencies(IServiceCollection services)
        {
            MapRepositories(services);
            MapManagers(services);
            MapMisc(services);
        }
        private static void MapRepositories(IServiceCollection services)
        {
            services.AddScoped<IPisacRepository, PisacRepository>();
        }

        private static void MapManagers(IServiceCollection services)
        {
            services.AddScoped<IPisacManager, PisacManager>();
        }

        private static void MapMisc(IServiceCollection services)
        {

        }

    }
}
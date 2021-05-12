using DogAndPeoples.Application.Services;
using DogAndPeoples.Domain.Interfaces;
using DogAndPeoples.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DogAndPeoples.Infra.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Sql Server Repository
            SqlServerRepository(services);

            // Application
            Application(services);
        }

        public static T GetService<T>()
        {
            var serviceCollection = new ServiceCollection();
            RegisterServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider.GetService<T>();
        }

        public static T Resolve<T>()
        {
            return GetService<T>();
        }

        private static void SqlServerRepository(IServiceCollection services)
        {
            services.AddTransient<ICaesRepository, CaesRepository>();
            services.AddTransient<IDonosRepository, DonosRepository>();
            services.AddTransient<ICaesDonosRepository, CaesDonosRepository>();
        }

        private static void Application(IServiceCollection services)
        {
            services.AddTransient<ICaesDonosService, CaesDonosService>();
        }
    }
}
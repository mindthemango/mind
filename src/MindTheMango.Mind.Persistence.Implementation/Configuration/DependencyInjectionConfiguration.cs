using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MindTheMango.Mind.Persistence.Contract;
using MindTheMango.Mind.Persistence.Implementation.Context;
using Scrutor;

namespace MindTheMango.Mind.Persistence.Implementation.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseContext(configuration);
            services.AddRepositories(configuration);
            
            return services;
        }

        private static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MindTheMangoDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("MindTheMangoDatabase"));
            });

            return services;
        }
        
        private static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            // Register every repository
            services.Scan(scan => scan
                .FromAssemblyOf<UnitOfWork>()
                .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Repository")))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            
            // Register UoW as scoped
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
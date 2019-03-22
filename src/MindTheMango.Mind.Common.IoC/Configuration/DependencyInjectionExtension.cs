using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MindTheMango.Mind.Common.Configuration;
using MindTheMango.Mind.Common.Identity.Configuration;
using MindTheMango.Mind.Common.Identity.Context;
using MindTheMango.Mind.Domain.Configuration;
using MindTheMango.Mind.Persistence.Implementation.Configuration;
using MindTheMango.Mind.Persistence.Implementation.Context;

namespace MindTheMango.Mind.Common.IoC.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPipelines(configuration);
            services.AddIdentityDependencies(configuration);
            services.AddDomainDependencies(configuration);
            services.AddPersistenceDependencies(configuration);

            return services;
        }

        public static void InitializeDatabases(this IApplicationBuilder app, IConfiguration configuration)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<MindTheMangoAccountDbContext>().Database.Migrate();
                serviceScope.ServiceProvider.GetRequiredService<MindTheMangoDbContext>().Database.Migrate();
            }
        }

    }
}
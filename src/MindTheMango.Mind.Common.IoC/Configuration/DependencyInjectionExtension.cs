using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MindTheMango.Mind.Common.Configuration;
using MindTheMango.Mind.Common.Identity.Configuration;
using MindTheMango.Mind.Persistence.Implementation.Configuration;

namespace MindTheMango.Mind.Common.IoC.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPipelines(configuration);
            services.AddIdentityDependencies(configuration);
            services.AddPersistenceDependencies(configuration);

            return services;
        }
    }
}
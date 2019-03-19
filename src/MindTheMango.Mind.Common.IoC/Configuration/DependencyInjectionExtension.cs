using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MindTheMango.Mind.Common.Identity.Configuration;

namespace MindTheMango.Mind.Common.IoC.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityDependencies(configuration);

            return services;
        }
    }
}
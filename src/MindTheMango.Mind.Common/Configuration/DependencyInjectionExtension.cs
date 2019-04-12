using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MindTheMango.Mind.Common.Pipeline;

namespace MindTheMango.Mind.Common.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddPipelines(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR();

            return services;
        }
    }
}
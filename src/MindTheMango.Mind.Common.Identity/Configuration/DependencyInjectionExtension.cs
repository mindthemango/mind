using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MindTheMango.Mind.Common.Identity.Context;

namespace MindTheMango.Mind.Common.Identity.Configuration
{
    public static class DependencyInjectionExtension
    {
        private static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MindTheMangoAccountDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("MindTheMangoAccountDatabase"));
            });

            return services;
        }
    }
}
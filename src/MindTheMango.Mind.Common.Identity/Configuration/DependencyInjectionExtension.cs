using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MindTheMango.Mind.Common.Identity.Context;

namespace MindTheMango.Mind.Common.Identity.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddIdentityDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseContext(configuration);
            services.AddIdentityCore(configuration);
            
            return services;
        }
        
        private static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MindTheMangoAccountDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("MindTheMangoAccountDatabase"));
            });

            return services;
        }
        
        private static IServiceCollection AddIdentityCore(this IServiceCollection services, IConfiguration configuration)
        {
            // configure identity options
            var identityBuilder = services.AddIdentityCore<Account>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 8;
            });
            
            identityBuilder = new IdentityBuilder(identityBuilder.UserType, typeof(AccountRole), identityBuilder.Services);

            identityBuilder.AddEntityFrameworkStores<MindTheMangoAccountDbContext>().AddDefaultTokenProviders();

            return services;
        }
    }
}
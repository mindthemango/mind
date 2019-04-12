using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MindTheMango.Mind.Common.Identity.Context;
using MindTheMango.Mind.Common.Identity.Logic.CreateAccount;

namespace MindTheMango.Mind.Common.Identity.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddIdentityDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseContext(configuration);
            services.AddIdentityCore(configuration);
            services.AddCustomValidation(configuration);
            
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
                o.Password.RequireLowercase = true;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 8;
            });
            
            identityBuilder = new IdentityBuilder(identityBuilder.UserType, typeof(AccountRole), identityBuilder.Services);

            identityBuilder.AddEntityFrameworkStores<MindTheMangoAccountDbContext>().AddDefaultTokenProviders();

            return services;
        }

        private static IServiceCollection AddCustomValidation(this IServiceCollection services, IConfiguration configuration)
        {
            AssemblyScanner.FindValidatorsInAssemblyContaining<CreateAccountCommandValidator>().ForEach(result => {
                services.AddTransient(result.InterfaceType, result.ValidatorType);
            });

            return services;
        }
    }
}
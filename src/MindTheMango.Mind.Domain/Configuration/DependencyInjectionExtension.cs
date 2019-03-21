using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MindTheMango.Mind.Domain.Business.UserLogic.CreateUser;

namespace MindTheMango.Mind.Domain.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatRHandlers(configuration);
            services.AddCustomValidation(configuration);
            
            return services;
        }
        
        private static IServiceCollection AddMediatRHandlers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(CreateUserCommandHandler).GetTypeInfo().Assembly);

            return services;
        }

        private static IServiceCollection AddCustomValidation(this IServiceCollection services, IConfiguration configuration)
        {
//            AssemblyScanner.FindValidatorsInAssemblyContaining<CreateAccountCommandValidator>().ForEach(result => {
//                services.AddTransient(result.InterfaceType, result.ValidatorType);
//            });

            return services;
        }
    }
}
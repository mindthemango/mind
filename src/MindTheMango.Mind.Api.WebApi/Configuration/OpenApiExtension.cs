using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MindTheMango.Mind.Api.WebApi.Configuration
{
    internal static class OpenApiConfiguration
    {
        public static IServiceCollection AddCustomOpenApi(this IServiceCollection services, IConfiguration configuration)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = configuration["OpenApi:Title"], Version = "v1" });
                
                    var mindWebApi = Path.Combine(System.AppContext.BaseDirectory, "MindTheMango.Mind.Api.WebApi.xml");

                    c.IncludeXmlComments(mindWebApi, true);
                });
            }
  
            return services;
        }
        
        public static void UseCustomSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", configuration["OpenApi:Title"]); });
        }
    }
}
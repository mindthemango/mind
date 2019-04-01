using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MindTheMango.Mind.Api.WebApi.Configuration
{
    internal static class AuthenticationExtension
    {
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Security:Jwt:SecretKey"]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
//                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Security:Jwt:Issuer"],
                    ValidAudience = configuration["Security:Jwt:Audience"],
                    IssuerSigningKey = securityKey
                };
            });
            
            return services;
        }
    }
}
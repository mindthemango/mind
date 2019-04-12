using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Api.WebApi.Factory
{
    internal class JwtFactory
    {
        protected readonly ILogger<JwtFactory> Logger;
        private readonly IConfiguration _configuration;
        private readonly SigningCredentials _signingCredentials;

        public JwtFactory(ILogger<JwtFactory> logger, IConfiguration configuration)
        {
            Logger = logger;
            _configuration = configuration;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Security:Jwt:SecretKey"]));
            _signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        }

        public Result<string> GenerateEncodedToken(ClaimsIdentity identity)
        {
            var timeNow = DateTime.UtcNow;
            
            identity.AddClaim(GenerateJti());

            try
            {
                var jwt = new JwtSecurityToken(
                    issuer: _configuration["Security:Jwt:Issuer"],
                    audience: _configuration["Security:Jwt:Audience"],
                    claims: identity.Claims,
                    notBefore: timeNow,
                    expires: timeNow.Add(TimeSpan.FromMinutes(double.Parse(_configuration["Security:Jwt:ValidFor"]))),
                    signingCredentials: _signingCredentials
                );

                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                
                return Result<string>.Success(encodedJwt);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Unhandled error generating JWT Encoded Token");
                return Result<string>.UnknownError(new List<string> {e.Message});
            }
        }

        private static Claim GenerateJti() => new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());
    }
}
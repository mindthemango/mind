using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
using MindTheMango.Mind.Application.Contract.Service;
using MindTheMango.Mind.Common.Identity;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Application.Implementation.Service
{
    public class AuthService : IAuthService
    {
        protected readonly UserManager<Account> AccountManager;
        protected readonly ILogger<AuthService> Logger;
        
        public AuthService(ILogger<AuthService> logger, UserManager<Account> accountManager)
        {
            Logger = logger;
            AccountManager = accountManager;
        }

        public async Task<Result<ClaimsIdentity>> SignIn(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return Result<ClaimsIdentity>.ValidationFailure(new List<string> {"username/password must not be empty."});
            }
            
            var account = await AccountManager.FindByEmailAsync(email);            

            if (account == null)
            {
                return Result<ClaimsIdentity>.NotFound(new List<string> {"username/password combination is wrong or the account does not exists."});
            }
            
            if (!await AccountManager.CheckPasswordAsync(account, password))
            {
                return Result<ClaimsIdentity>.NotFound(new List<string> {"username/password combination is wrong or the account does not exists."});
            }

            var claims = await GetClaimsIdentity(account);

            return Result<ClaimsIdentity>.Success(claims);
        }

        protected async Task<ClaimsIdentity> GetClaimsIdentity(Account account)
        {
            var claims = await AccountManager.GetClaimsAsync(account);
            
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, account.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, account.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, account.UserName));
            
            return new ClaimsIdentity(new GenericIdentity(account.UserName), claims);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MindTheMango.Mind.Application.Contract.Service;
using MindTheMango.Mind.Common.Identity;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Application.Implementation.Service
{
    public class AuthService : IAuthService
    {
        protected readonly UserManager<Account> AccountManager;
        protected readonly SignInManager<Account> SignInManager;
        protected readonly ILogger<AuthService> Logger;
        
        public AuthService(ILogger<AuthService> logger, UserManager<Account> accountManager, SignInManager<Account> signInManager)
        {
            Logger = logger;
            AccountManager = accountManager;
            SignInManager = signInManager;
        }

        public async Task<Result<ClaimsPrincipal>> SignIn(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return Result<ClaimsPrincipal>.ValidationFailure(new List<string> {"username/password must not be empty."});
            }
            
            var account = await AccountManager.FindByEmailAsync(email);            

            if (account == null)
            {
                return Result<ClaimsPrincipal>.NotFound(new List<string> {"username/password combination is wrong or the account does not exists."});
            }
            
            if (!await AccountManager.CheckPasswordAsync(account, password))
            {
                return Result<ClaimsPrincipal>.NotFound(new List<string> {"username/password combination is wrong or the account does not exists."});
            }
            
            var claims = await SignInManager.CreateUserPrincipalAsync(account);

            return Result<ClaimsPrincipal>.Success(claims);
        }
    }
}
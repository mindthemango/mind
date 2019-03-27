using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MindTheMango.Mind.Common.Request;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Common.Identity.Logic.CreateAccount
{
    public class CreateAccountCommandHandler : RequestHandler<CreateAccountCommand, Result<Guid>>
    {
        private readonly UserManager<Account> _userManager;

        public CreateAccountCommandHandler(ILogger<RequestHandler<CreateAccountCommand, Result<Guid>>> logger, UserManager<Account> userManager) : base(logger)
        {
            _userManager = userManager;
        }

        public override async Task<Result<Guid>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Account()
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                UserName = request.Username
            };

            var result = await _userManager.CreateAsync(account, request.Password);

            if (!result.Succeeded)
            {
                var error = result.Errors.FirstOrDefault();
                
                if (error != null)
                {
                    return Result<Guid>.Fail("identity_error", new List<string> {$"{error.Code}: {error.Description}"});
                }
            }
            
            Logger.LogTrace($"Created new account {account.Id} ({account.Email})");

            
            return Result<Guid>.Success(account.Id);

        }
    }
}
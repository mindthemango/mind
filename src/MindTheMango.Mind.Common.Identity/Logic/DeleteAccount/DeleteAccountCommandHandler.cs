using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MindTheMango.Mind.Common.Request;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Common.Identity.Logic.DeleteAccount
{
    public class DeleteAccountCommandHandler : RequestHandler<DeleteAccountCommand, Result<Guid>>
    {
        private readonly UserManager<Account> _userManager;

        public DeleteAccountCommandHandler(ILogger<RequestHandler<DeleteAccountCommand, Result<Guid>>> logger, UserManager<Account> userManager) : base(logger)
        {
            _userManager = userManager;
        }

        public override async Task<Result<Guid>> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _userManager.FindByIdAsync(request.Id.ToString());
            
            if (account == null)
            {
                return Result<Guid>.NotFound(new List<string> {"the requested account does not exists."});
            }

            await _userManager.DeleteAsync(account);
            
            Logger.LogTrace($"Deleted account {request.Id}");
            
            return Result<Guid>.Success(request.Id);
        }
    }
}
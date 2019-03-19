using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MindTheMango.Mind.Common.Request;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Domain.Business.UserLogic.CreateUser
{
    public class CreateUserCommandHandler : RequestHandler<CreateUserCommand, Result<Guid>>
    {
        public CreateUserCommandHandler(ILogger<RequestHandler<CreateUserCommand, Result<Guid>>> logger) : base(logger)
        {
        }

        public override Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
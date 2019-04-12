using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MindTheMango.Mind.Common.Request;
using MindTheMango.Mind.Common.Result;
using MindTheMango.Mind.Domain.Entity;
using MindTheMango.Mind.Persistence.Contract;

namespace MindTheMango.Mind.Domain.Business.Users.CreateUser
{
    public class CreateUserCommandHandler : RequestHandler<CreateUserCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(ILogger<RequestHandler<CreateUserCommand, Result<Guid>>> logger, IUnitOfWork unitOfWork) : base(logger)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Id = request.Id,
                Name = request.Name,
                Surname = request.Surname,
                RegistrationDate = request.Timestamp,
                Timestamp = request.Timestamp
            };
            
            await _unitOfWork.UserRepository.Insert(user);

            await _unitOfWork.SaveAsync(cancellationToken);
            
            Logger.LogTrace("Created new user {@User}", user);
            
            return Result<Guid>.Success(user.Id);
        }
    }
}
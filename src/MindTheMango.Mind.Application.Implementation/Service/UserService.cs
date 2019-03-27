using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using MindTheMango.Mind.Application.Contract.Dto;
using MindTheMango.Mind.Application.Contract.Service;
using MindTheMango.Mind.Common.Identity.Logic.CreateAccount;
using MindTheMango.Mind.Common.Identity.Logic.DeleteAccount;
using MindTheMango.Mind.Common.Result;
using MindTheMango.Mind.Domain.Business.Users.CreateUser;

namespace MindTheMango.Mind.Application.Implementation.Service
{
    public class UserService : IUserService
    {
        protected readonly IMediator MediatR;
        protected readonly ILogger<UserService> Logger;

        public UserService(IMediator mediatR, ILogger<UserService> logger)
        {
            MediatR = mediatR;
            Logger = logger;
        }

        public Task<Result<UserDto>> Find(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to create a new user.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Result<Guid>> Create(string name, string surname, string username, string email, string password,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var accountResult = await MediatR.Send(new CreateAccountCommand
                {
                    Email = email,
                    Username = username,
                    Password = password
                }, cancellationToken);
                
                if (!accountResult.Succeeded)
                {
                    return accountResult;
                }
                
                var userResult = await MediatR.Send(new CreateUserCommand
                {
                    Id = accountResult.Value,
                    Name = name,
                    Surname = surname
                }, cancellationToken);

                if (!userResult.Succeeded)
                {
                    await MediatR.Send(new DeleteAccountCommand
                    {
                        Id = accountResult.Value
                    }, cancellationToken);
                }
                
                return userResult;
            }
            catch (Exception e)
            {
                var code = Guid.NewGuid().ToString();
                
                Logger.LogError($"Unhandled error creating user (error trace code: {code})", e);
                
                return Result<Guid>.Fail("unknown_error", new List<string> {$"Unknown error while creating a new user. Trace code: {code}"});
            }
        }
    }
}
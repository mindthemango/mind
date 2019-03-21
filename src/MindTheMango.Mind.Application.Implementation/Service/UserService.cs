using System;
using System.Threading;
using System.Threading.Tasks;
using MindTheMango.Mind.Application.Contract.Dto;
using MindTheMango.Mind.Application.Contract.Service;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Application.Implementation.Service
{
    public class UserService : IUserService
    {
        public Task<Result<UserDto>> Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Guid>> Create(string name, string surname, string username, string email, string password,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
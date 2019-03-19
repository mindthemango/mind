using System;
using System.Threading.Tasks;
using MindTheMango.Mind.Application.Contract.Service;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Application.Implementation.Service
{
    public class UserService : IUserService
    {
        public Task<Result<Guid>> CreateUser(string name, string surname, string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
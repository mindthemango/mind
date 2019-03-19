using System;
using System.Threading.Tasks;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Application.Contract.Service
{
    public interface IUserService
    {
        Task<Result<Guid>> CreateUser(string name, string surname, string email, string password);
    }
}
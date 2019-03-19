using System;
using System.Threading.Tasks;
using MindTheMango.Mind.Application.Contract.Dto;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Application.Contract.Service
{
    public interface IUserService
    {
        Task<Result<UserDto>> Find(Guid id);

        Task<Result<Guid>> Create(string name, string surname, string username, string email, string password);
    }
}
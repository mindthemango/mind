using System.Security.Claims;
using System.Threading.Tasks;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Application.Contract.Service
{
    public interface IAuthService
    {
        Task<Result<ClaimsPrincipal>> SignIn(string email, string password);
    }
}
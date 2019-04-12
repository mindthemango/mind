using System.Security.Claims;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Api.WebApi.Factory.Jwt
{
    public interface IJwtFactory
    {
        Result<string> GenerateEncodedToken(ClaimsIdentity identity);
    }
}
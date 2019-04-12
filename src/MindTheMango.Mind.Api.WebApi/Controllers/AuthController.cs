using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindTheMango.Mind.Api.WebApi.Factory.Jwt;
using MindTheMango.Mind.Api.WebApi.Model.Auth;
using MindTheMango.Mind.Application.Contract.Service;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Api.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtFactory _jwtFactory;

        public AuthController(IAuthService authService, IJwtFactory jwtFactory)
        {
            _authService = authService;
            _jwtFactory = jwtFactory;
        }

        /// <summary>
        /// Endpoint for signing a user.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Returns the auth token to use in Bearer authentication method.</response>
        [HttpPost]
        [AllowAnonymous]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SignInResponseModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> SignIn([FromBody] SignInModel model, CancellationToken cancellationToken)
        {
            var signInResult = await _authService.SignIn(model.Email, model.Password);

            if (!signInResult.Succeeded) return ErrorInResultHandler(signInResult);
            
            var encodedTokenResult = _jwtFactory.GenerateEncodedToken(signInResult.Value);

            if (!encodedTokenResult.Succeeded) return ErrorInResultHandler(encodedTokenResult);

            var response = new SignInResponseModel()
            {
                AuthToken = encodedTokenResult.Value,
            };
            
            return Ok(response);
        }

        /// <summary>
        /// Endpoint for testing authentication.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Returns a message with timestamp and the username of the authenticated user</response>
        [HttpGet]
        [Route("ping")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        public IActionResult AuthorizedPing(CancellationToken cancellationToken)
        {
            return Ok(new
            {
                Message = "Your auth token works!",
                Timestamp = DateTime.Now,
                Username = HttpContext.User.Identity.Name
            });
        }
        
        private IActionResult ErrorInResultHandler(IResult result)
        {
            if (result.Errors.ContainsKey("unknown_error"))
            {
                return StatusCode(500, new
                {
                    Error = result.Errors["unknown_error"],
                    Message = "Please try again later. If the error persists, contact the administrators and supply the related trace code (if any)."
                });
            }
            
            if (result.Errors.ContainsKey("validation_failures"))
            {
                return BadRequest(new
                {
                    Error = result.Errors["validation_failures"],
                    Message = "One or more validation errors have occurred."
                });
            }   
            
            if (result.Errors.ContainsKey("identity_error"))
            {
                return BadRequest(new
                {
                    Error = result.Errors["identity_error"]
                });
            }
            
            return StatusCode(500, new
            {
                Error = "Unknown fatal error.",
                Message = "Please try again later. If the error persists, contact the administrators."
            });
        }
    }
}
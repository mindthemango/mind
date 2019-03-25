using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MindTheMango.Mind.Api.WebApi.Model.User;
using MindTheMango.Mind.Application.Contract.Service;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Api.WebApi.Controllers
{
    /// <summary>
    /// Controller for user related endpoints.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Public constructor of UserController
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Endpoint for creating a new user.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Returns the GUID of the created user.</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserModel model, CancellationToken cancellationToken)
        {
            var result = await _userService.Create(model.Name, model.Surname, model.Username, model.Email, model.Password, cancellationToken);

            return result.Succeeded 
                ? Ok(result.Value)
                : ErrorInResultHandler(result);
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
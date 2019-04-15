using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindTheMango.Mind.Api.WebApi.Model.Note;
using MindTheMango.Mind.Api.WebApi.Model.User;
using MindTheMango.Mind.Application.Contract.Service;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Api.WebApi.Controllers
{
    /// <summary>
    /// Controller for note related endpoints.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        /// <summary>
        /// Public constructor of NoteController.
        /// </summary>
        /// <param name="noteService"></param>
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }
        
        /// <summary>
        /// Endpoint for creating a new note.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Returns the GUID of the created note.</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateNote([FromBody] CreateNoteModel model, CancellationToken cancellationToken)
        {
            var userId = new Guid(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            var result = await _noteService.Create(userId, model.Title, model.Content, cancellationToken);

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
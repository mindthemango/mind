using System;
using MindTheMango.Mind.Common.Request;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Common.Identity.Logic.CreateAccount
{
    public class CreateAccountCommand : Request<Result<Guid>>
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
using System;
using MindTheMango.Mind.Common.Request;

namespace MindTheMango.Mind.Common.Identity.Logic.CreateAccount
{
    public class CreateAccountCommand : Request<Guid>
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
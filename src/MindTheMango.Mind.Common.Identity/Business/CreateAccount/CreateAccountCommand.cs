using System;
using MindTheMango.Mind.Common.Request;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Common.Identity.Business.CreateAccount
{
    public class CreateAccountCommand : Request<Result<Guid>>
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public CreateAccountCommand(string email, string username, string password)
        {
            Email = email;
            Username = username;
            Password = password;
        }
    }
}
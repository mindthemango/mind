using System;
using MindTheMango.Mind.Common.Request;

namespace MindTheMango.Mind.Common.Identity.Logic.DeleteAccount
{
    public class DeleteAccountCommand : Request<Guid>
    {
        public Guid Id { get; set; }
    }
}
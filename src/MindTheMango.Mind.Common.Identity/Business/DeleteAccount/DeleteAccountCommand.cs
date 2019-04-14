using System;
using MindTheMango.Mind.Common.Request;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Common.Identity.Business.DeleteAccount
{
    public class DeleteAccountCommand : Request<Result<Guid>>
    {
        public Guid Id { get; set; }

        public DeleteAccountCommand(Guid id)
        {
            Id = id;
        }
    }
}
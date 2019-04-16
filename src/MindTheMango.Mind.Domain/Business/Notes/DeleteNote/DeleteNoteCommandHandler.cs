using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MindTheMango.Mind.Common.Request;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Domain.Business.Notes.DeleteNote
{
    public class DeleteNoteCommandHandler : RequestHandler<DeleteNoteCommand, Result>
    {
        public DeleteNoteCommandHandler(ILogger<RequestHandler<DeleteNoteCommand, Result>> logger) : base(logger)
        {
        }

        public override Task<Result> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
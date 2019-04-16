using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MindTheMango.Mind.Common.Request;
using MindTheMango.Mind.Common.Result;
using MindTheMango.Mind.Domain.Entity;

namespace MindTheMango.Mind.Domain.Business.Notes.FindNote
{
    public class FindNoteCommandHandler : RequestHandler<FindNoteCommand, Result<Note>>
    {
        public FindNoteCommandHandler(ILogger<RequestHandler<FindNoteCommand, Result<Note>>> logger) : base(logger)
        {
        }

        public override Task<Result<Note>> Handle(FindNoteCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
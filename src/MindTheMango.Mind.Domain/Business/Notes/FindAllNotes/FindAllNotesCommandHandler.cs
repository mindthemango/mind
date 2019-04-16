using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MindTheMango.Mind.Common.Request;
using MindTheMango.Mind.Common.Result;
using MindTheMango.Mind.Domain.Entity;

namespace MindTheMango.Mind.Domain.Business.Notes.FindAllNotes
{
    public class FindAllNotesCommandHandler : RequestHandler<FindAllNotesCommand, Result<IList<Note>>>
    {
        public FindAllNotesCommandHandler(ILogger<RequestHandler<FindAllNotesCommand, Result<IList<Note>>>> logger) : base(logger)
        {
        }

        public override Task<Result<IList<Note>>> Handle(FindAllNotesCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
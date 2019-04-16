using System.Collections.Generic;
using MindTheMango.Mind.Common.Request;
using MindTheMango.Mind.Common.Result;
using MindTheMango.Mind.Domain.Entity;

namespace MindTheMango.Mind.Domain.Business.Notes.FindAllNotes
{
    public class FindAllNotesCommand : Request<Result<IList<Note>>>
    {
        
    }
}
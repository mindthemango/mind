using System;
using MindTheMango.Mind.Common.Request;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Domain.Business.Notes.CreateNote
{
    public class CreateNoteCommand : Request<Result<Guid>>
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
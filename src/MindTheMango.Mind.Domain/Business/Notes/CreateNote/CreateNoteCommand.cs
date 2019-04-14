using System;
using MindTheMango.Mind.Common.Request;
using MindTheMango.Mind.Common.Result;
using MindTheMango.Mind.Domain.Entity;

namespace MindTheMango.Mind.Domain.Business.Notes.CreateNote
{
    public class CreateNoteCommand : Request<Result<Guid>>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public CreateNoteCommand(Guid userId, string title, string content)
        {
            UserId = userId;
            Title = title;
            Content = content;
        }
    }
}
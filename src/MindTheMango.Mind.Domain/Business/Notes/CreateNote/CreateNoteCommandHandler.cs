using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MindTheMango.Mind.Common.Request;
using MindTheMango.Mind.Common.Result;
using MindTheMango.Mind.Domain.Entity;
using MindTheMango.Mind.Persistence.Contract;

namespace MindTheMango.Mind.Domain.Business.Notes.CreateNote
{
    public class CreateNoteCommandHandler : RequestHandler<CreateNoteCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateNoteCommandHandler(ILogger<RequestHandler<CreateNoteCommand, Result<Guid>>> logger, IUnitOfWork unitOfWork) : base(logger)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<Result<Guid>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Note()
            {
                Id = Guid.NewGuid(),
                Title = request.Title ?? "",
                Content = request.Content ?? "",
                CreationDate = request.Timestamp,
                Timestamp = request.Timestamp
            };

            await _unitOfWork.NoteRepository.Insert(note);

            await _unitOfWork.SaveAsync(cancellationToken);

            Logger.LogTrace("Created new note {@Note}", note);

            return Result<Guid>.Success(note.Id);
        }
    }
}
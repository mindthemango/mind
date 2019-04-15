using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using MindTheMango.Mind.Application.Contract.Dto;
using MindTheMango.Mind.Application.Contract.Service;
using MindTheMango.Mind.Common.Result;
using MindTheMango.Mind.Domain.Business.Notes.CreateNote;

namespace MindTheMango.Mind.Application.Implementation.Service
{
    public class NoteService : INoteService
    {
        protected readonly IMediator MediatR;
        protected readonly ILogger<UserService> Logger;

        public NoteService(IMediator mediatR, ILogger<UserService> logger)
        {
            MediatR = mediatR;
            Logger = logger;
        }

        public Task<Result<NoteDto>> Find(Guid userId, Guid noteId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IList<NoteDto>>> FindAll(Guid userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<Guid>> Create(Guid userId, string title, string content, CancellationToken cancellationToken)
        {
            try
            {
                var noteResult = await MediatR.Send(new CreateNoteCommand(userId, title, content), cancellationToken);

                return noteResult;
            }
            catch (Exception e)
            {
                var code = Guid.NewGuid().ToString();
                 
                Logger.LogError(e, "Unhandled error creating note ({TraceCode})", code);
                
                return Result<Guid>.UnknownError(new List<string> {$"Unknown error while creating a new note. Trace code: {code}"});
            }
        }

        public Task<Result> Delete(Guid userId, Guid noteId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
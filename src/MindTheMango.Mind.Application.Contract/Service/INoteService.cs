using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MindTheMango.Mind.Application.Contract.Dto;
using MindTheMango.Mind.Common.Result;

namespace MindTheMango.Mind.Application.Contract.Service
{
    public interface INoteService
    {
        Task<Result<NoteDto>> Find(Guid userId, Guid noteId, CancellationToken cancellationToken);
        Task<Result<IList<NoteDto>>> FindAll(Guid userId, CancellationToken cancellationToken);
        Task<Result<Guid>> Create(Guid userId, string title, string content, CancellationToken cancellationToken);
        Task<Result> Delete(Guid userId, Guid noteId, CancellationToken cancellationToken);
    }
}
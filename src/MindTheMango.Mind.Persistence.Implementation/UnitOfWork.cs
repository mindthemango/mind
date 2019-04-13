using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MindTheMango.Mind.Domain.Entity;
using MindTheMango.Mind.Persistence.Contract;
using MindTheMango.Mind.Persistence.Contract.Repository;
using MindTheMango.Mind.Persistence.Implementation.Context;

namespace MindTheMango.Mind.Persistence.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly MindTheMangoDbContext Context;
        protected readonly ILogger<UnitOfWork> Logger;
        private bool _disposed;

        public IUserRepository UserRepository { get; set; }
        public INoteRepository NoteRepository { get; set; }

        public UnitOfWork(MindTheMangoDbContext context, ILogger<UnitOfWork> logger, 
            IUserRepository userRepository, INoteRepository noteRepository)
        {
            Context = context;
            Logger = logger;
            UserRepository = userRepository;
            NoteRepository = noteRepository;
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await Context.SaveChangesAsync(cancellationToken);
                
                Logger.LogInformation("Database save operation finished correctly.");
            }
            catch (DbUpdateConcurrencyException e)
            {
                Logger.LogError(e, "Database save operation failed, concurrency related.");

                throw;
            }
            catch (DbUpdateException e)
            {
                Logger.LogError(e, "Database save operation failed.");

                throw;
            }
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
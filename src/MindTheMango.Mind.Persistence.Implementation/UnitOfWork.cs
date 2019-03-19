using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        public UnitOfWork(MindTheMangoDbContext context, ILogger<UnitOfWork> logger, 
            IUserRepository userRepository)
        {
            Context = context;
            Logger = logger;
            UserRepository = userRepository;
        }

        public async Task SaveAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
                
                Logger.LogInformation("Database save operation finished correctly.");
            }
            catch (DbUpdateConcurrencyException exception)
            {
                Logger.LogError(exception, "Database save operation failed, concurrency related.");

                throw;
            }
            catch (DbUpdateException exception)
            {
                Logger.LogError(exception, "Database save operation failed.");

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
using Microsoft.EntityFrameworkCore;
using MindTheMango.Mind.Domain.Entity;
using MindTheMango.Mind.Persistence.Contract.Repository;
using MindTheMango.Mind.Persistence.Implementation.Context;

namespace MindTheMango.Mind.Persistence.Implementation.Repository
{
    public class NoteRepository : GenericRepository<Note>, INoteRepository
    {
        public NoteRepository(MindTheMangoDbContext dbContext) : base(dbContext)
        {
        }
    }
}
using Microsoft.EntityFrameworkCore;
using MindTheMango.Mind.Domain.Entity;
using MindTheMango.Mind.Persistence.Contract.Repository;

namespace MindTheMango.Mind.Persistence.Implementation.Repository
{
    public class NoteRepository : GenericRepository<Note>, INoteRepository
    {
        public NoteRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
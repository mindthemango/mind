using Microsoft.EntityFrameworkCore;
using MindTheMango.Mind.Domain.Entity;

namespace MindTheMango.Mind.Persistence.Implementation.Context
{
    public class MindTheMangoDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        protected MindTheMangoDbContext()
        {
        }

        public MindTheMangoDbContext(DbContextOptions<MindTheMangoDbContext> options) : base(options)
        {
        }
    }
}
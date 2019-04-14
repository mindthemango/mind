using System;
using Microsoft.EntityFrameworkCore;
using MindTheMango.Mind.Domain.Entity;

namespace MindTheMango.Mind.Persistence.Implementation.Context
{
    public class MindTheMangoDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Note> Notes { get; set; }

        public MindTheMangoDbContext()
        {
        }

        public MindTheMangoDbContext(DbContextOptions<MindTheMangoDbContext> options) : base(options)
        {
        }
    }
}
using System;
using Microsoft.EntityFrameworkCore;
using MindTheMango.Mind.Domain.Entity;

namespace MindTheMango.Mind.Persistence.Implementation.Context
{
    public class MindTheMangoDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public MindTheMangoDbContext()
        {
        }

        public MindTheMangoDbContext(DbContextOptions<MindTheMangoDbContext> options) : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("MINDTHEMANGO_DATABASE") ?? throw new NullReferenceException());
            }
        }
    }
}
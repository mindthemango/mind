using System;
using System.IO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MindTheMango.Mind.Common.Identity.Context
{
    public class MindTheMangoAccountDbContext : IdentityDbContext<Account, AccountRole, Guid>
    {
        public MindTheMangoAccountDbContext()
        {
        }
        
        public MindTheMangoAccountDbContext(DbContextOptions<MindTheMangoAccountDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("MINDTHEMANGO_DATABASE_ACCOUNT") ?? throw new NullReferenceException());
            }
        }
    }
}
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
    }
}
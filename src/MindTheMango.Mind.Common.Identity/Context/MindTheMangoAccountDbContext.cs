using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MindTheMango.Mind.Common.Identity.Context
{
    public class MindTheMangoAccountDbContext : IdentityDbContext<Account, AccountRole, Guid>
    {
        
    }
}
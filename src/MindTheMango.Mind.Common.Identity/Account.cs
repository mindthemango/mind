using System;
using Microsoft.AspNetCore.Identity;

namespace MindTheMango.Mind.Common.Identity
{
    public class Account : IdentityUser<Guid>
    {
        
    }
    
    public class AccountRole : IdentityRole<Guid>
    {
        
    }
}
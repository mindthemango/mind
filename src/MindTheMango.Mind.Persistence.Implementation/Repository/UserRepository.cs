using MindTheMango.Mind.Domain.Entity;
using MindTheMango.Mind.Persistence.Contract.Repository;
using MindTheMango.Mind.Persistence.Implementation.Context;

namespace MindTheMango.Mind.Persistence.Implementation.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MindTheMangoDbContext dbContext) : base(dbContext)
        {
        }
    }
}
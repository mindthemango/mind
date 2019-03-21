using System.Threading;
using System.Threading.Tasks;
using MindTheMango.Mind.Persistence.Contract.Repository;

namespace MindTheMango.Mind.Persistence.Contract
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; set; }

        Task SaveAsync(CancellationToken cancellationToken);
    }
}
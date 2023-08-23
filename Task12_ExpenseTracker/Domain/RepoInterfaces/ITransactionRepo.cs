using Domain.Models;

namespace Domain.RepoInterfaces
{
    public interface ITransactionRepo : IGenericRepo<Transaction, Guid>
    {
    }
}

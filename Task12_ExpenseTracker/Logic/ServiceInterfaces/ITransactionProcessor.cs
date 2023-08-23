using Domain.Models;

namespace Logic.ServiceInterfaces
{
    public interface ITransactionProcessor
    {
        Task<Transaction> ProcessTransaction(Transaction transaction);
    }
}

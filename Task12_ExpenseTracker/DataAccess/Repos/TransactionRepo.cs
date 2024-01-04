using Domain.Models;
using Domain.RepoInterfaces;

namespace DataAccess.Repos
{
    public class TransactionRepo : GenericRepo<Transaction, Guid>, ITransactionRepo
    {
        public TransactionRepo(AppDbContext context) : base(context)
        {
        }
    }
}

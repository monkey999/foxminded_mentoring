using Domain.Models.Accounts;
using Domain.Models.BaseEntities;
using Domain.RepoInterfaces;

namespace DataAccess.Repos
{
    public class TransactionParticipantRepo : GenericRepo<TransactionParticipant, Guid>, ITransactionParticipantRepo
    {
        public TransactionParticipantRepo(AppDbContext context) : base(context)
        {
        }
    }
}

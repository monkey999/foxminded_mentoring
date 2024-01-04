using Domain.Models.Accounts;
using Domain.RepoInterfaces;

namespace DataAccess.Repos
{
    public class DebitAccountRepo : GenericRepo<DebitAccount, Guid>, IDebitAccountRepo
    {
        public DebitAccountRepo(AppDbContext context) : base(context)
        {
        }
    }
}

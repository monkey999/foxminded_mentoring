using Domain.Models.BaseEntities;
using Domain.RepoInterfaces;

namespace DataAccess.Repos
{
    public class AccountBaseRepo : GenericRepo<AccountBase, Guid>, IAccountBaseRepo
    {
        public AccountBaseRepo(AppDbContext context) : base(context)
        {
        }
    }
}

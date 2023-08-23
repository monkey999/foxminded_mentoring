using Domain.Models.Accounts;
using Domain.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repos
{
    public class DebitAccountRepo : GenericRepo<DebitAccount, Guid>, IDebitAccountRepo
    {
        public DebitAccountRepo(AppDbContext context) : base(context)
        {
        }
    }
}

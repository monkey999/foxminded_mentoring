using Domain.Models;
using Domain.Models.Accounts;
using Domain.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repos
{
    public class DebtAccountRepo : GenericRepo<DebtAccount, Guid>, IDebtAccountRepo
    {
        public DebtAccountRepo(AppDbContext context) : base(context)
        {
        }
    }
}

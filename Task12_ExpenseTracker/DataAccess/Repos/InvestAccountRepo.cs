using Domain.Models.Accounts;
using Domain.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repos
{
    public class InvestAccountRepo : GenericRepo<InvestAccount, Guid>, IInvestAccountRepo
    {
        public InvestAccountRepo(AppDbContext context) : base(context)
        {
        }
    }
}

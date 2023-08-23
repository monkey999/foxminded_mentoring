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
    public class CreditAccountRepo : GenericRepo<CreditAccount, Guid>, ICreditAccountRepo
    {
        public CreditAccountRepo(AppDbContext context) : base(context)
        {
        }
    }
}

using Domain.Models;
using Domain.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Specifications.AccountBaseSpecs
{
    public class AccountBaseGetAllSpecification : BaseSpecification<AccountBase>
    {
        public AccountBaseGetAllSpecification()
        {
        }

        public AccountBaseGetAllSpecification(Expression<Func<AccountBase, bool>> criteria)
            : base(criteria)
        {
            AddOrderBy(x => x.Id);
        }
    }
}

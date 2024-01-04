using Domain.Models.BaseEntities;
using System.Linq.Expressions;

namespace DataAccess.Specifications.AccountBaseSpecs
{
    public class AccountBaseGetByIdSpecification : BaseSpecification<AccountBase>
    {
        public AccountBaseGetByIdSpecification()
        {
        }

        public AccountBaseGetByIdSpecification(Expression<Func<AccountBase, bool>> criteria)
            : base(criteria)
        {
        }
    }
}

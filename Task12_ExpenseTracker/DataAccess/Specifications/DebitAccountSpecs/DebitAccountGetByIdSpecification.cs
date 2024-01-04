using Domain.Models.Accounts;
using System.Linq.Expressions;

namespace DataAccess.Specifications.DebitAccountSpecs
{
    public class DebitAccountGetByIdSpecification : BaseSpecification<DebitAccount>
    {
        public DebitAccountGetByIdSpecification()
        {
        }

        public DebitAccountGetByIdSpecification(Expression<Func<DebitAccount, bool>> criteria)
            : base(criteria)
        {
        }
    }
}

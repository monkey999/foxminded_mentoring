using Domain.Models.Accounts;
using System.Linq.Expressions;

namespace DataAccess.Specifications.DebitAccountSpecs
{
    public class DebitAccountGetAllSpecification : BaseSpecification<DebitAccount>
    {
        public DebitAccountGetAllSpecification()
        {
        }

        public DebitAccountGetAllSpecification(Expression<Func<DebitAccount, bool>> criteria)
            : base(criteria)
        {
            AddOrderBy(x => x.Id);
        }
    }
}

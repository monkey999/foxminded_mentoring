using Domain.Models;
using Domain.Models.Accounts;
using System.Linq.Expressions;

namespace DataAccess.Specifications.DebitAccountSpecs
{
    public class DebitAccountGetByIdAsNoTrackingSpecification : BaseSpecification<DebitAccount>
    {
        public DebitAccountGetByIdAsNoTrackingSpecification()
        {
        }

        public DebitAccountGetByIdAsNoTrackingSpecification(Expression<Func<DebitAccount, bool>> criteria)
            : base(criteria)
        {
            ApplyAsNoTracking(true);
        }
    }
}
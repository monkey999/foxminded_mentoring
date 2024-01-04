using Domain.Models;
using System.Linq.Expressions;

namespace DataAccess.Specifications.TransactionSpecs
{
    public class TransactionGetByIdAsNoTrackingSpecification : BaseSpecification<Transaction>
    {
        public TransactionGetByIdAsNoTrackingSpecification()
        {
        }

        public TransactionGetByIdAsNoTrackingSpecification(Expression<Func<Transaction, bool>> criteria)
            : base(criteria)
        {
            ApplyAsNoTracking(true);
        }
    }
}

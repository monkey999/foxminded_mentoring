using Domain.Models;
using System.Linq.Expressions;

namespace DataAccess.Specifications.TransactionSpecs
{
    public class TransactionGetByIdSpecification : BaseSpecification<Transaction>
    {
        public TransactionGetByIdSpecification()
        {
        }

        public TransactionGetByIdSpecification(Expression<Func<Transaction, bool>> criteria)
            : base(criteria)
        {
        }
    }
}

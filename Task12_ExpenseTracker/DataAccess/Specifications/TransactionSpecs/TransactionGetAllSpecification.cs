using Domain.Models;
using System.Linq.Expressions;

namespace DataAccess.Specifications.TransactionSpecs
{
    public class TransactionGetAllSpecification : BaseSpecification<Transaction>
    {
        public TransactionGetAllSpecification()
        {
        }

        public TransactionGetAllSpecification(Expression<Func<Transaction, bool>> criteria)
            : base(criteria)
        {
            AddOrderBy(x => x.Id);
        }
    }
}

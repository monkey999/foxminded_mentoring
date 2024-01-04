using System.Linq.Expressions;

namespace DataAccess.Specifications.TransactionParticipant
{
    public class TransactionParticipantGetAllSpecification : BaseSpecification<Domain.Models.BaseEntities.TransactionParticipant>
    {
        public TransactionParticipantGetAllSpecification()
        {
        }

        public TransactionParticipantGetAllSpecification(Expression<Func<Domain.Models.BaseEntities.TransactionParticipant, bool>> criteria)
            : base(criteria)
        {
            AddOrderBy(x => x.Id);
        }
    }
}

using Domain.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Specifications.TransactionParticipant
{
    public class TransactionParticipantGetByIdSpecification : BaseSpecification<Domain.Models.BaseEntities.TransactionParticipant>
    {
        public TransactionParticipantGetByIdSpecification()
        {
        }

        public TransactionParticipantGetByIdSpecification(Expression<Func<Domain.Models.BaseEntities.TransactionParticipant, bool>> criteria)
            : base(criteria)
        {
        }
    }
}

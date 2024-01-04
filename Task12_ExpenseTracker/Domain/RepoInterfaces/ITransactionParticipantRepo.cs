using Domain.Models.BaseEntities;

namespace Domain.RepoInterfaces
{
    public interface ITransactionParticipantRepo : IGenericRepo<TransactionParticipant, Guid>
    {
    }
}

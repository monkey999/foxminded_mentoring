using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Responses.Create;

namespace Logic.ServiceInterfaces
{
    public interface ITransactionProcessor
    {
        Task<CreateTransactionRespDTO> ProcessTransaction(CreateTransactionReqDTO transaction, CancellationToken cancellationToken);
    }
}

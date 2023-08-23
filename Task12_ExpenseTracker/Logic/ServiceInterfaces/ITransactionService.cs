using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.DTO_Contracts.Responses.Create;
using Logic.DTO_Contracts.Responses.Get;
using Logic.DTO_Contracts.Responses.Update;

namespace Logic.ServiceInterfaces
{
    public interface ITransactionService
    {
        Task<bool> CreateTransactionAsync(CreateTransactionReqDTO createTransaction);
        Task<CreateTransactionRespDTO> CreateTransactionWithResultAsync(CreateTransactionReqDTO createTransaction);
        Task<bool> DeleteTransactionAsync(Guid transactionId);
        Task<GetTransactionRespDto> GetAllTransactionsAsync();
        Task<GetTransactionRespDto> GetTransactionByIdAsync(Guid transactionId);
        Task<UpdateTransactionRespDTO> UpdateTransactionAsync(UpdateTransactionReqDTO transaction);
    }
}

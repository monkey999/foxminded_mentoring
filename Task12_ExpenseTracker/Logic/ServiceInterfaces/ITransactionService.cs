using Domain.Models;
using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.DTO_Contracts.Responses.Create;
using Logic.DTO_Contracts.Responses.Delete;
using Logic.DTO_Contracts.Responses.Get;
using Logic.DTO_Contracts.Responses.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace Logic.ServiceInterfaces
{
    public interface ITransactionService
    {
        Task<CreateTransactionRespDTO> CreateTransactionAsync(CreateTransactionReqDTO createTransactionDto, CancellationToken cancellationToken);
        Task<DeleteTransactionRespDTO> DeleteTransactionAsync(Guid transactionId, CancellationToken cancellationToken);
        Task<GetTransactionRespDto> GetAllTransactionsAsync(CancellationToken cancellationToken);
        Task<GetTransactionRespDto> GetTransactionByIdAsync(Guid transactionId, CancellationToken cancellationToken);
        Task<UpdateTransactionRespDTO> UpdateTransactionAsync(UpdateTransactionReqDTO transactionDto, CancellationToken cancellationToken);
        Task<UpdateTransactionPatchRespDto> UpdateTransactionPatchAsync(Guid Id, JsonPatchDocument<Transaction> patchDocument, CancellationToken cancellationToken);
    }
}

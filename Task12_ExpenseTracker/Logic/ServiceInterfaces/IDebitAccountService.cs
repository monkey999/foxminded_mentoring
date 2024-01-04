using Domain.Models.Accounts;
using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.DTO_Contracts.Responses.Create;
using Logic.DTO_Contracts.Responses.Delete;
using Logic.DTO_Contracts.Responses.Get;
using Logic.DTO_Contracts.Responses.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace Logic.ServiceInterfaces
{
    public interface IDebitAccountService
    {
        Task<CreateDebitAccountRespDTO> CreateDebitAccountAsync(CreateDebitAccountReqDTO createDebitAccountDto, CancellationToken cancellationToken);
        Task<DeleteDebitAccountRespDTO> DeleteDebitAccountAsync(Guid debitAccountId, CancellationToken cancellationToken);
        Task<GetDebitAccountRespDto> GetAllDebitAccountsAsync(CancellationToken cancellationToken);
        Task<GetDebitAccountRespDto> GetDebitAccountByIdAsync(Guid debitAccountId, CancellationToken cancellationToken);
        Task<UpdateDebitAccountRespDTO> UpdateDebitAccountAsync(UpdateDebitAccountReqDTO debitAccountDto, CancellationToken cancellationToken);
        Task<UpdateDebitAccountPatchRespDto> UpdateDebitAccountPatchAsync(Guid Id, JsonPatchDocument<DebitAccount> patchDocument, CancellationToken cancellationToken);
    }
}

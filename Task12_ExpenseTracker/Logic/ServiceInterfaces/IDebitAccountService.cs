using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.DTO_Contracts.Responses.Create;
using Logic.DTO_Contracts.Responses.Get;
using Logic.DTO_Contracts.Responses.Update;

namespace Logic.ServiceInterfaces
{
    public interface IDebitAccountService
    {
        Task<bool> CreateDebitAccountAsync(CreateDebitAccountReqDTO createDebitAccount);
        Task<CreateDebitAccountRespDTO> CreateDebitAccountWithResultAsync(CreateDebitAccountReqDTO createDebitAccount);
        Task<bool> DeleteDebitAccountAsync(Guid debitAccountId);
        Task<GetDebitAccountRespDto> GetAllDebitAccountsAsync();
        Task<GetDebitAccountRespDto> GetDebitAccountByIdAsync(Guid debitAccountId);
        Task<UpdateDebitAccountRespDTO> UpdateDebitAccountAsync(UpdateDebitAccountReqDTO debitAccount);
    }
}

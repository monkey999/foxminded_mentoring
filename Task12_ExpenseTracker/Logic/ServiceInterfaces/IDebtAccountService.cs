using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.DTO_Contracts.Responses.Create;
using Logic.DTO_Contracts.Responses.Get;
using Logic.DTO_Contracts.Responses.Update;

namespace Logic.ServiceInterfaces
{
    public interface IDebtAccountService
    {
        Task<bool> CreateDebtAccountAsync(CreateDebtAccountReqDTO createDebtAccount);
        Task<CreateDebtAccountRespDTO> CreateDebtAccountWithResultAsync(CreateDebtAccountReqDTO createDebtAccount);
        Task<bool> DeleteDebtAccountAsync(Guid debtAccountId);
        Task<GetDebtAccountRespDto> GetAllDebtAccountsAsync();
        Task<GetDebtAccountRespDto> GetDebtAccountByIdAsync(Guid debtAccountId);
        Task<UpdateDebtAccountRespDTO> UpdateDebtAccountAsync(UpdateDebtAccountReqDTO debtAccount);
    }
}

using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.DTO_Contracts.Responses.Create;
using Logic.DTO_Contracts.Responses.Get;
using Logic.DTO_Contracts.Responses.Update;

namespace Logic.ServiceInterfaces
{
    public interface IInvestAccountService
    {
        Task<bool> CreateInvestAccountAsync(CreateInvestAccountReqDTO createInvestAccount);
        Task<CreateInvestAccountRespDTO> CreateInvestAccountWithResultAsync(CreateInvestAccountReqDTO createInvestAccount);
        Task<bool> DeleteInvestAccountAsync(Guid investAccountId);
        Task<GetInvestAccountRespDto> GetAllInvestAccountsAsync();
        Task<GetInvestAccountRespDto> GetInvestAccountByIdAsync(Guid investAccountId);
        Task<UpdateInvestAccountRespDTO> UpdateInvestAccountAsync(UpdateInvestAccountReqDTO investAccount);
    }
}

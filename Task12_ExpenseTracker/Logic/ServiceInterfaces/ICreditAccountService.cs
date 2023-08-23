using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.DTO_Contracts.Responses.Create;
using Logic.DTO_Contracts.Responses.Get;
using Logic.DTO_Contracts.Responses.Update;

namespace Logic.ServiceInterfaces
{
    public interface ICreditAccountService
    {
        Task<bool> CreateCreditAccountAsync(CreateCreditAccountReqDTO createCreditAccount);
        Task<CreateCreditAccountRespDTO> CreateCreditAccountWithResultAsync(CreateCreditAccountReqDTO createCreditAccount);
        Task<bool> DeleteCreditAccountAsync(Guid creditAccountId);
        Task<GetCreditAccountRespDto> GetAllCreditAccountsAsync();
        Task<GetCreditAccountRespDto> GetCreditAccountByIdAsync(Guid creditAccountId);
        Task<UpdateCreditAccountRespDTO> UpdateCreditAccountAsync(UpdateCreditAccountReqDTO creditAccount);
    }
}

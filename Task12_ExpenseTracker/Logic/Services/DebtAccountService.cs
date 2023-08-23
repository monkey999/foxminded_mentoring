using AutoMapper;
using Domain.Models;
using Domain.Models.Accounts;
using Domain.RepoInterfaces;
using Domain.ValueObjects;
using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.DTO_Contracts.Responses.Create;
using Logic.DTO_Contracts.Responses.Get;
using Logic.DTO_Contracts.Responses.Update;
using Logic.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Logic.Services
{
    public class DebtAccountService : IDebtAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DebtAccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateDebtAccountAsync(CreateDebtAccountReqDTO createDebtAccountDto)
        {
            var debtAccount = _mapper.Map<DebtAccount>(createDebtAccountDto);

            await _unitOfWork.DebtAccounts.AddAsync(debtAccount);

            var created = await _unitOfWork.SaveChangesAsyncWithResult();

            return created > 0;
        }

        public async Task<CreateDebtAccountRespDTO> CreateDebtAccountWithResultAsync(CreateDebtAccountReqDTO createDebtAccountDto)
        {
            var debtAccount = _mapper.Map<DebtAccount>(createDebtAccountDto);

            await _unitOfWork.DebtAccounts.AddAsync(debtAccount);

            var created = await _unitOfWork.SaveChangesAsyncWithResult();

            if (created > 0)
            {
                var response = _mapper.Map<CreateDebtAccountRespDTO>(debtAccount);

                return response;
            }

            return new CreateDebtAccountRespDTO
            {
                ErrorMessage = new ErrorMessage
                {
                    StatusCode = 500,
                    Message = "Error occurred while creating DebtAccount."
                }
            };
        }

        public async Task<bool> DeleteDebtAccountAsync(Guid debtAccountId)
        {
            var debtAccount = await GetDebtAccountByIdAsync(debtAccountId);

            if (debtAccount == null)
            {
                return false;
            }

            _unitOfWork.DebtAccounts.RemoveById(debtAccountId);

            var deleted = await _unitOfWork.SaveChangesAsyncWithResult();

            return deleted > 0;
        }

        public async Task<GetDebtAccountRespDto> GetAllDebtAccountsAsync()
        {
            var debtAccounts = await _unitOfWork.DebtAccounts.GetAll().OrderBy(x => x.Id).ToListAsync();

            if (debtAccounts != null)
            {
                var response = new GetDebtAccountRespDto
                {
                    DebtAccountsRespDto = _mapper.Map<IEnumerable<GetDebtAccountRespDto.DebtAccountRespDto>>(debtAccounts)
                };

                return response;
            }

            return new GetDebtAccountRespDto
            {
                ErrorMessage = new ErrorMessage
                {
                    StatusCode = 404,
                    Message = "DebtAccounts not found."
                }
            };
        }

        public async Task<GetDebtAccountRespDto> GetDebtAccountByIdAsync(Guid debtAccountId)
        {
            var debtAccount = await _unitOfWork.DebtAccounts.FindByCondition(x => x.Id.Equals(debtAccountId))
                .SingleOrDefaultAsync();

            var response = new GetDebtAccountRespDto();

            if (debtAccount != null)
            {
                var DebtAccountDto = _mapper.Map<GetDebtAccountRespDto.DebtAccountRespDto>(debtAccount);
                response.DebtAccountsRespDto = new List<GetDebtAccountRespDto.DebtAccountRespDto> { DebtAccountDto };
            }
            else
            {
                response.ErrorMessage = new ErrorMessage
                {
                    StatusCode = 404,
                    Message = "DebtAccount not found."
                };
            }

            return response;
        }

        public async Task<UpdateDebtAccountRespDTO> UpdateDebtAccountAsync(UpdateDebtAccountReqDTO debtAccountDto)
        {
            var debtAccountToUpdate = _mapper.Map<DebtAccount>(debtAccountDto);

            _unitOfWork.DebtAccounts.Update(debtAccountToUpdate);

            var updated = await _unitOfWork.SaveChangesAsyncWithResult();

            if (updated > 0)
            {
                var updatedDebtAccount = _unitOfWork.DebtAccounts.FindByCondition(x => x.Id == debtAccountDto.Id).SingleOrDefault();

                var response = _mapper.Map<UpdateDebtAccountRespDTO>(updatedDebtAccount);

                return response;
            }

            return new UpdateDebtAccountRespDTO
            {
                ErrorMessage = new ErrorMessage
                {
                    StatusCode = 500,
                    Message = "Error occurred while updating DebtAccount. Probably you haven't provided DebtAccount ID!"
                }
            };
        }
    }
}

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
    public class DebitAccountService : IDebitAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DebitAccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateDebitAccountAsync(CreateDebitAccountReqDTO createDebitAccountDto)
        {
            var debitAccount = _mapper.Map<DebitAccount>(createDebitAccountDto);

            await _unitOfWork.DebitAccounts.AddAsync(debitAccount);

            var created = await _unitOfWork.SaveChangesAsyncWithResult();

            return created > 0;
        }

        public async Task<CreateDebitAccountRespDTO> CreateDebitAccountWithResultAsync(CreateDebitAccountReqDTO createDebitAccountDto)
        {
            var debitAccount = _mapper.Map<DebitAccount>(createDebitAccountDto);

            await _unitOfWork.DebitAccounts.AddAsync(debitAccount);

            var created = await _unitOfWork.SaveChangesAsyncWithResult();

            if (created > 0)
            {
                var response = _mapper.Map<CreateDebitAccountRespDTO>(debitAccount);

                return response;
            }

            return new CreateDebitAccountRespDTO
            {
                ErrorMessage = new ErrorMessage
                {
                    StatusCode = 500,
                    Message = "Error occurred while creating DebitAccount."
                }
            };
        }

        public async Task<bool> DeleteDebitAccountAsync(Guid debitAccountId)
        {
            var debitAccount = await GetDebitAccountByIdAsync(debitAccountId);

            if (debitAccount == null)
            {
                return false;
            }

            _unitOfWork.DebitAccounts.RemoveById(debitAccountId);

            var deleted = await _unitOfWork.SaveChangesAsyncWithResult();

            return deleted > 0;
        }

        public async Task<GetDebitAccountRespDto> GetAllDebitAccountsAsync()
        {
            var debitAccounts = await _unitOfWork.DebitAccounts.GetAll().OrderBy(x => x.Id).ToListAsync();

            if (debitAccounts != null)
            {
                var response = new GetDebitAccountRespDto
                {
                    DebitAccountsRespDto = _mapper.Map<IEnumerable<GetDebitAccountRespDto.DebitAccountRespDto>>(debitAccounts)
                };

                return response;
            }

            return new GetDebitAccountRespDto
            {
                ErrorMessage = new ErrorMessage
                {
                    StatusCode = 404,
                    Message = "DebitAccounts not found."
                }
            };
        }

        public async Task<GetDebitAccountRespDto> GetDebitAccountByIdAsync(Guid debitAccountId)
        {
            var debitAccount = await _unitOfWork.DebitAccounts.FindByCondition(x => x.Id.Equals(debitAccountId))
                .SingleOrDefaultAsync();

            var response = new GetDebitAccountRespDto();

            if (debitAccount != null)
            {
                var debitAccountDto = _mapper.Map<GetDebitAccountRespDto.DebitAccountRespDto>(debitAccount);
                response.DebitAccountsRespDto = new List<GetDebitAccountRespDto.DebitAccountRespDto> { debitAccountDto };
            }
            else
            {
                response.ErrorMessage = new ErrorMessage
                {
                    StatusCode = 404,
                    Message = "DebitAccount not found."
                };
            }

            return response;
        }

        public async Task<UpdateDebitAccountRespDTO> UpdateDebitAccountAsync(UpdateDebitAccountReqDTO debitAccountDto)
        {
            var debitAccountToUpdate = _mapper.Map<DebitAccount>(debitAccountDto);

            _unitOfWork.DebitAccounts.Update(debitAccountToUpdate);

            var updated = await _unitOfWork.SaveChangesAsyncWithResult();

            if (updated > 0)
            {
                var updatedDebitAccount = _unitOfWork.DebitAccounts.FindByCondition(x => x.Id == debitAccountDto.Id).SingleOrDefault();

                var response = _mapper.Map<UpdateDebitAccountRespDTO>(updatedDebitAccount);

                return response;
            }

            return new UpdateDebitAccountRespDTO
            {
                ErrorMessage = new ErrorMessage
                {
                    StatusCode = 500,
                    Message = "Error occurred while updating DebitAccount. Probably you haven't provided DebitAccount ID!"
                }
            };
        }
    }
}

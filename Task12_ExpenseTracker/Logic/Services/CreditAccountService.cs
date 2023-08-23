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
    public class CreditAccountService : ICreditAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreditAccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateCreditAccountAsync(CreateCreditAccountReqDTO createCreditAccountDto)
        {
            var category = _mapper.Map<Category>(createCreditAccountDto);

            await _unitOfWork.Categories.AddAsync(category);

            var created = await _unitOfWork.SaveChangesAsyncWithResult();

            return created > 0;
        }

        public async Task<CreateCreditAccountRespDTO> CreateCreditAccountWithResultAsync(CreateCreditAccountReqDTO createCreditAccountDto)
        {
            var creditAccount = _mapper.Map<CreditAccount>(createCreditAccountDto);

            await _unitOfWork.CreditAccounts.AddAsync(creditAccount);

            var created = await _unitOfWork.SaveChangesAsyncWithResult();

            if (created > 0)
            {
                var response = _mapper.Map<CreateCreditAccountRespDTO>(creditAccount);

                return response;
            }

            return new CreateCreditAccountRespDTO
            {
                ErrorMessage = new ErrorMessage
                {
                    StatusCode = 500,
                    Message = "Error occurred while creating creditAccount."
                }
            };
        }

        public async Task<bool> DeleteCreditAccountAsync(Guid creditAccountId)
        {
            var creditAccount = await GetCreditAccountByIdAsync(creditAccountId);

            if (creditAccount == null)
            {
                return false;
            }

            _unitOfWork.CreditAccounts.RemoveById(creditAccountId);

            var deleted = await _unitOfWork.SaveChangesAsyncWithResult();

            return deleted > 0;
        }

        public async Task<GetCreditAccountRespDto> GetAllCreditAccountsAsync()
        {
            var creditAccounts = await _unitOfWork.CreditAccounts.GetAll().OrderBy(x => x.Id).ToListAsync();

            if (creditAccounts != null)
            {
                var response = new GetCreditAccountRespDto
                {
                    CreditAccountsRespDto = _mapper.Map<IEnumerable<GetCreditAccountRespDto.CreditAccountRespDto>>(creditAccounts)
                };

                return response;
            }

            return new GetCreditAccountRespDto
            {
                ErrorMessage = new ErrorMessage
                {
                    StatusCode = 404,
                    Message = "CreditAccounts not found."
                }
            };
        }

        public async Task<GetCreditAccountRespDto> GetCreditAccountByIdAsync(Guid creditAccountId)
        {
            var creditAccount = await _unitOfWork.CreditAccounts.FindByCondition(x => x.Id.Equals(creditAccountId))
                .SingleOrDefaultAsync();

            var response = new GetCreditAccountRespDto();

            if (creditAccount != null)
            {
                var creditAccountDto = _mapper.Map<GetCreditAccountRespDto.CreditAccountRespDto>(creditAccount);
                response.CreditAccountsRespDto = new List<GetCreditAccountRespDto.CreditAccountRespDto> { creditAccountDto };
            }
            else
            {
                response.ErrorMessage = new ErrorMessage
                {
                    StatusCode = 404,
                    Message = "CreditAccount not found."
                };
            }

            return response;
        }

        public async Task<UpdateCreditAccountRespDTO> UpdateCreditAccountAsync(UpdateCreditAccountReqDTO creditAccountDto)
        {
            var creditAccountToUpdate = _mapper.Map<CreditAccount>(creditAccountDto);

            _unitOfWork.CreditAccounts.Update(creditAccountToUpdate);

            var updated = await _unitOfWork.SaveChangesAsyncWithResult();

            if (updated > 0)
            {
                var updatedCreditAccount = _unitOfWork.CreditAccounts.FindByCondition(x => x.Id == creditAccountDto.Id).SingleOrDefault();

                var response = _mapper.Map<UpdateCreditAccountRespDTO>(updatedCreditAccount);

                return response;
            }
            
            return new UpdateCreditAccountRespDTO
            {
                ErrorMessage = new ErrorMessage
                {
                    StatusCode = 500,
                    Message = "Error occurred while updating creditAccount. Probably you haven't provided creditAccount ID!"
                }
            };
        }
    }
}

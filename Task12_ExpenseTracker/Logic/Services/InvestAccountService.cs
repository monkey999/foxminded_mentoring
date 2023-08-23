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
    public class InvestAccountService : IInvestAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvestAccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateInvestAccountAsync(CreateInvestAccountReqDTO createInvestAccountDto)
        {
            var investAccount = _mapper.Map<InvestAccount>(createInvestAccountDto);

            await _unitOfWork.InvestAccounts.AddAsync(investAccount);

            var created = await _unitOfWork.SaveChangesAsyncWithResult();

            return created > 0;
        }

        public async Task<CreateInvestAccountRespDTO> CreateInvestAccountWithResultAsync(CreateInvestAccountReqDTO createInvestAccountDto)
        {
            var investAccount = _mapper.Map<InvestAccount>(createInvestAccountDto);

            await _unitOfWork.InvestAccounts.AddAsync(investAccount);

            var created = await _unitOfWork.SaveChangesAsyncWithResult();

            if (created > 0)
            {
                var response = _mapper.Map<CreateInvestAccountRespDTO>(investAccount);

                return response;
            }

            return new CreateInvestAccountRespDTO
            {
                ErrorMessage = new ErrorMessage
                {
                    StatusCode = 500,
                    Message = "Error occurred while creating InvestAccount."
                }
            };
        }

        public async Task<bool> DeleteInvestAccountAsync(Guid investAccountId)
        {
            var investAccount = await GetInvestAccountByIdAsync(investAccountId);

            if (investAccount == null)
            {
                return false;
            }

            _unitOfWork.InvestAccounts.RemoveById(investAccountId);

            var deleted = await _unitOfWork.SaveChangesAsyncWithResult();

            return deleted > 0;
        }

        public async Task<GetInvestAccountRespDto> GetAllInvestAccountsAsync()
        {
            var investAccounts = await _unitOfWork.InvestAccounts.GetAll().OrderBy(x => x.Id).ToListAsync();

            if (investAccounts != null)
            {
                var response = new GetInvestAccountRespDto
                {
                    InvestAccountsRespDto = _mapper.Map<IEnumerable<GetInvestAccountRespDto.InvestAccountRespDto>>(investAccounts)
                };

                return response;
            }

            return new GetInvestAccountRespDto
            {
                ErrorMessage = new ErrorMessage
                {
                    StatusCode = 404,
                    Message = "InvestAccounts not found."
                }
            };
        }

        public async Task<GetInvestAccountRespDto> GetInvestAccountByIdAsync(Guid investAccountId)
        {
            var investAccount = await _unitOfWork.InvestAccounts.FindByCondition(x => x.Id.Equals(investAccountId))
                .SingleOrDefaultAsync();

            var response = new GetInvestAccountRespDto();

            if (investAccount != null)
            {
                var investAccountDto = _mapper.Map<GetInvestAccountRespDto.InvestAccountRespDto>(investAccount);
                response.InvestAccountsRespDto = new List<GetInvestAccountRespDto.InvestAccountRespDto> { investAccountDto };
            }
            else
            {
                response.ErrorMessage = new ErrorMessage
                {
                    StatusCode = 404,
                    Message = "InvestAccount not found."
                };
            }

            return response;
        }

        public async Task<UpdateInvestAccountRespDTO> UpdateInvestAccountAsync(UpdateInvestAccountReqDTO investAccountDto)
        {
            var investAccountToUpdate = _mapper.Map<InvestAccount>(investAccountDto);

            _unitOfWork.InvestAccounts.Update(investAccountToUpdate);

            var updated = await _unitOfWork.SaveChangesAsyncWithResult();

            if (updated > 0)
            {
                var updatedInvestAccount = _unitOfWork.InvestAccounts.FindByCondition(x => x.Id == investAccountDto.Id).SingleOrDefault();

                var response = _mapper.Map<UpdateInvestAccountRespDTO>(updatedInvestAccount);

                return response;
            }

            return new UpdateInvestAccountRespDTO
            {
                ErrorMessage = new ErrorMessage
                {
                    StatusCode = 500,
                    Message = "Error occurred while updating InvestAccount. Probably you haven't provided InvestAccount ID!"
                }
            };
        }
    }
}

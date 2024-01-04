using AutoMapper;
using DataAccess.Specifications.DebitAccountSpecs;
using Domain.Models.Accounts;
using Domain.RepoInterfaces;
using Domain.ValueObjects;
using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Requests.Update;
using Logic.DTO_Contracts.Responses.Create;
using Logic.DTO_Contracts.Responses.Delete;
using Logic.DTO_Contracts.Responses.Get;
using Logic.DTO_Contracts.Responses.Update;
using Logic.ServiceInterfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.IdentityModel.Tokens;
using System.Transactions;

namespace Logic.Services
{
    public class DebitAccountService : IDebitAccountService
    {
        private readonly IUnitOfWOrk _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDebitAccountRepo _debitAccountRepo;

        public DebitAccountService(IUnitOfWOrk unitOfWork, IMapper mapper, IDebitAccountRepo debitAccountRepo)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _debitAccountRepo = debitAccountRepo;
        }

        public async Task<CreateDebitAccountRespDTO> CreateDebitAccountAsync(CreateDebitAccountReqDTO createDebitAccountDto, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var debitAccount = _mapper.Map<DebitAccount>(createDebitAccountDto);

                await _debitAccountRepo.AddAsync(debitAccount, cancellationToken);

                var response = _mapper.Map<CreateDebitAccountRespDTO>(debitAccount);

                if ((await _unitOfWork.SaveChangesAsyncWithResult(cancellationToken)) == 0)
                {
                    return new CreateDebitAccountRespDTO
                    {
                        ErrorMessage = new ErrorMessage
                        {
                            StatusCode = 400,
                            Message = "Debit account wasn't created!"
                        }
                    };
                }

                scope.Complete();

                return response;
            }
        }

        public async Task<DeleteDebitAccountRespDTO> DeleteDebitAccountAsync(Guid debitAccountId, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if ((await _debitAccountRepo
                    .FindByConditionAsync(cancellationToken, new DebitAccountGetByIdAsNoTrackingSpecification(x => x.Id == debitAccountId)))
                        .IsNullOrEmpty())
                {
                    return new DeleteDebitAccountRespDTO
                    {
                        Deleted = false,
                        Error = new ErrorMessage
                        {
                            StatusCode = 400,
                            Message = "Such debit account doesn't exist!"
                        }
                    };
                }

                _debitAccountRepo.RemoveById(debitAccountId);

                if ((await _unitOfWork.SaveChangesAsyncWithResult(cancellationToken)) == 0)
                {
                    return new DeleteDebitAccountRespDTO
                    {
                        Deleted = false,
                        Error = new ErrorMessage
                        {
                            StatusCode = 400,
                            Message = "Error occurred while deleting debit account!"
                        }
                    };
                }

                scope.Complete();

                var response = new DeleteDebitAccountRespDTO
                {
                    Deleted = true
                };

                return response;
            }
        }

        public async Task<GetDebitAccountRespDto> GetAllDebitAccountsAsync(CancellationToken cancellationToken)
        {
            if ((await _debitAccountRepo.FindByConditionAsync(cancellationToken, new DebitAccountGetAllSpecification()))
                .IsNullOrEmpty())
            {
                return new GetDebitAccountRespDto
                {
                    ErrorMessage = new ErrorMessage
                    {
                        StatusCode = 404,
                        Message = $"No debit accounts were found!"
                    }
                };
            }

            var allDebitAccs = await _debitAccountRepo.FindByConditionAsync(cancellationToken, new DebitAccountGetAllSpecification());

            var response = new GetDebitAccountRespDto
            {
                DebitAccountsRespDto = _mapper.Map<IEnumerable<DebitAccountRespDto>>(allDebitAccs)
            };

            return response;
        }

        public async Task<GetDebitAccountRespDto> GetDebitAccountByIdAsync(Guid debitAccountId, CancellationToken cancellationToken)
        {
            if ((await _debitAccountRepo.FindByConditionAsync(cancellationToken, new DebitAccountGetByIdAsNoTrackingSpecification(c => c.Id == debitAccountId)))
                .IsNullOrEmpty())
            {
                return new GetDebitAccountRespDto
                {
                    ErrorMessage = new ErrorMessage
                    {
                        StatusCode = 404,
                        Message = "DebitAccount not found."
                    }
                };
            }

            var debitAccountByIdDto = await _debitAccountRepo
               .FindByConditionAsync(cancellationToken, new DebitAccountGetByIdSpecification(c => c.Id == debitAccountId));

            var mappedDebitAccountDto = _mapper.Map<DebitAccountRespDto>(debitAccountByIdDto);

            return new GetDebitAccountRespDto
            {
                DebitAccountsRespDto = new List<DebitAccountRespDto> { mappedDebitAccountDto }
            };
        }

        public async Task<UpdateDebitAccountRespDTO> UpdateDebitAccountAsync(UpdateDebitAccountReqDTO debitAccountDto, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if ((await _debitAccountRepo
                    .FindByConditionAsync(cancellationToken, new DebitAccountGetByIdAsNoTrackingSpecification(x => x.Id == debitAccountDto.Id)))
                        .IsNullOrEmpty())
                {
                    return new UpdateDebitAccountRespDTO
                    {
                        ErrorMessage = new ErrorMessage
                        {
                            StatusCode = 404,
                            Message = "Debit account not found."
                        }
                    };
                }

                var debitAccountToUpdate = ((await _debitAccountRepo
                    .FindByConditionAsync(cancellationToken, new DebitAccountGetByIdSpecification(x => x.Id == debitAccountDto.Id))))
                    .FirstOrDefault();

                var mappedDebitAccountToUpdateDto = _mapper.Map(debitAccountDto, debitAccountToUpdate);

                _debitAccountRepo.Update(mappedDebitAccountToUpdateDto);

                if ((await _unitOfWork.SaveChangesAsyncWithResult(cancellationToken)) == 0)
                {
                    return new UpdateDebitAccountRespDTO
                    {
                        ErrorMessage = new ErrorMessage
                        {
                            StatusCode = 400,
                            Message = "Error occurred while updating debit account!"
                        }
                    };
                }

                var response = _mapper.Map<UpdateDebitAccountRespDTO>(debitAccountToUpdate);

                scope.Complete();

                return response;
            }
        }

        public async Task<UpdateDebitAccountPatchRespDto> UpdateDebitAccountPatchAsync(Guid Id, JsonPatchDocument<DebitAccount> patchDocument, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if ((await _debitAccountRepo
                 .FindByConditionAsync(cancellationToken, new DebitAccountGetByIdAsNoTrackingSpecification(x => x.Id == Id)))
                     .IsNullOrEmpty())
                {
                    return new UpdateDebitAccountPatchRespDto
                    {
                        ErrorMessage = new ErrorMessage
                        {
                            StatusCode = 404,
                            Message = "Debit account not found."
                        }
                    };
                }

                var debitAccountToUpdate = (await _debitAccountRepo.FindByConditionAsync(cancellationToken, new DebitAccountGetByIdSpecification(x => x.Id == Id)))
                    .FirstOrDefault();

                patchDocument.ApplyTo(debitAccountToUpdate);

                if ((await _unitOfWork.SaveChangesAsyncWithResult(cancellationToken)) == 0)
                {
                    return new UpdateDebitAccountPatchRespDto
                    {
                        ErrorMessage = new ErrorMessage
                        {
                            StatusCode = 400,
                            Message = "Error occurred while patch updating debit account!"
                        }
                    };
                }

                var response = _mapper.Map<UpdateDebitAccountPatchRespDto>(debitAccountToUpdate);

                scope.Complete();

                return response;
            }
        }
    }
}

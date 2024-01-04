using AutoMapper;
using DataAccess.Specifications.TransactionSpecs;
using Domain.Enums;
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
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWOrk _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITransactionProcessor _transactionProcessor;
        private readonly ITransactionRepo _transactionRepo;

        public TransactionService(IUnitOfWOrk unitOfWork, IMapper mapper, ITransactionProcessor transactionProcessor, ITransactionRepo transactionRepo)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _transactionProcessor = transactionProcessor;
            _transactionRepo = transactionRepo;
        }

        public async Task<CreateTransactionRespDTO> CreateTransactionAsync(CreateTransactionReqDTO createTransactionDto, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (!Array.Exists(Enum.GetNames(typeof(TransactionType)), value => value == createTransactionDto.TransactionType))
                {
                    return new CreateTransactionRespDTO
                    {
                        ErrorMessage = new ErrorMessage
                        {
                            StatusCode = 400,
                            Message = "Such TransactionType doesn't exist!"
                        }
                    };
                }

                var processedTransaction = await _transactionProcessor.ProcessTransaction(createTransactionDto, cancellationToken);

                if (processedTransaction.ErrorMessage is not null)
                {
                    return processedTransaction;
                }

                var response = new CreateTransactionRespDTO()
                {
                    TransactionDto = _mapper.Map<TransactionRespForCreateDto>(processedTransaction.TransactionDto)
                };

                scope.Complete();

                return response;
            }
        }

        public async Task<DeleteTransactionRespDTO> DeleteTransactionAsync(Guid transactionId, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if ((await _transactionRepo
                    .FindByConditionAsync(cancellationToken, new TransactionGetByIdAsNoTrackingSpecification(x => x.Id == transactionId)))
                        .IsNullOrEmpty())
                {
                    return new DeleteTransactionRespDTO
                    {
                        Deleted = false,
                        Error = new ErrorMessage
                        {
                            StatusCode = 400,
                            Message = "Such transaction doesn't exist!"
                        }
                    };
                }

                _transactionRepo.RemoveById(transactionId);

                if ((await _unitOfWork.SaveChangesAsyncWithResult(cancellationToken)) == 0)
                {
                    return new DeleteTransactionRespDTO
                    {
                        Deleted = false,
                        Error = new ErrorMessage
                        {
                            StatusCode = 400,
                            Message = "Error occurred while deleting transaction!"
                        }
                    };
                }

                scope.Complete();

                var response = new DeleteTransactionRespDTO
                {
                    Deleted = true
                };

                return response;
            }
        }

        public async Task<GetTransactionRespDto> GetAllTransactionsAsync(CancellationToken cancellationToken)
        {
            if ((await _transactionRepo.FindByConditionAsync(cancellationToken, new TransactionGetAllSpecification()))
                .IsNullOrEmpty())
            {
                return new GetTransactionRespDto
                {
                    ErrorMessage = new ErrorMessage
                    {
                        StatusCode = 404,
                        Message = "Transactions not found."
                    }
                };
            }

            var allTransactions = await _transactionRepo
                    .FindByConditionAsync(cancellationToken, new TransactionGetAllSpecification());

            var response = new GetTransactionRespDto
            {
                TransactionsRespDto = _mapper.Map<IEnumerable<TransactionRespForGetDto>>(allTransactions)
            };

            return response;
        }

        public async Task<GetTransactionRespDto> GetTransactionByIdAsync(Guid transactionId, CancellationToken cancellationToken)
        {
            if ((await _transactionRepo.FindByConditionAsync(cancellationToken, new TransactionGetByIdAsNoTrackingSpecification(c => c.Id == transactionId)))
                .IsNullOrEmpty())
            {
                return new GetTransactionRespDto
                {
                    ErrorMessage = new ErrorMessage
                    {
                        StatusCode = 404,
                        Message = "Transaction not found."
                    }
                };
            }

            var transactionByIdDto = await _transactionRepo
                .FindByConditionAsync(cancellationToken, new TransactionGetByIdSpecification(c => c.Id == transactionId));

            var mappedTransactionDto = _mapper.Map<TransactionRespForGetDto>(transactionByIdDto);

            return new GetTransactionRespDto
            {
                TransactionsRespDto = new List<TransactionRespForGetDto> { mappedTransactionDto }
            };
        }

        public async Task<UpdateTransactionRespDTO> UpdateTransactionAsync(UpdateTransactionReqDTO transactionDto, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if ((await _transactionRepo
                    .FindByConditionAsync(cancellationToken, new TransactionGetByIdAsNoTrackingSpecification(x => x.Id == transactionDto.Id)))
                        .IsNullOrEmpty())
                {
                    return new UpdateTransactionRespDTO
                    {
                        ErrorMessage = new ErrorMessage
                        {
                            StatusCode = 404,
                            Message = "Transaction not found."
                        }
                    };
                }

                var transactionToUpdate = ((await _transactionRepo
                    .FindByConditionAsync(cancellationToken, new TransactionGetByIdSpecification(x => x.Id == transactionDto.Id))))
                    .FirstOrDefault();

                var mappedTransactionToUpdateDto = _mapper.Map(transactionDto, transactionToUpdate);

                _transactionRepo.Update(mappedTransactionToUpdateDto);

                if ((await _unitOfWork.SaveChangesAsyncWithResult(cancellationToken)) == 0)
                {
                    return new UpdateTransactionRespDTO
                    {
                        ErrorMessage = new ErrorMessage
                        {
                            StatusCode = 400,
                            Message = "Error occurred while updating transaction!"
                        }
                    };
                }

                var response = _mapper.Map<UpdateTransactionRespDTO>(transactionToUpdate);

                scope.Complete();

                return response;
            }
        }

        public async Task<UpdateTransactionPatchRespDto> UpdateTransactionPatchAsync(Guid Id, JsonPatchDocument<Domain.Models.Transaction> patchDocument, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if ((await _transactionRepo
                      .FindByConditionAsync(cancellationToken, new TransactionGetByIdAsNoTrackingSpecification(x => x.Id == Id)))
                          .IsNullOrEmpty())
                {
                    return new UpdateTransactionPatchRespDto
                    {
                        ErrorMessage = new ErrorMessage
                        {
                            StatusCode = 404,
                            Message = "transaction not found."
                        }
                    };
                }

                var transactionToUpdate = (await _transactionRepo
                    .FindByConditionAsync(cancellationToken, new TransactionGetByIdSpecification(x => x.Id == Id)))
                    .FirstOrDefault();

                patchDocument.ApplyTo(transactionToUpdate);

                if ((await _unitOfWork.SaveChangesAsyncWithResult(cancellationToken)) == 0)
                {
                    return new UpdateTransactionPatchRespDto
                    {
                        ErrorMessage = new ErrorMessage
                        {
                            StatusCode = 400,
                            Message = "Error occurred while patch updating transaction!"
                        }
                    };
                }

                var response = _mapper.Map<UpdateTransactionPatchRespDto>(transactionToUpdate);

                scope.Complete();

                return response;
            }
        }
    }
}

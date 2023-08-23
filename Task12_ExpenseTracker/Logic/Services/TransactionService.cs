using AutoMapper;
using Domain.Models;
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
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateTransactionAsync(CreateTransactionReqDTO createTransactionDto)
        {
            var transaction = _mapper.Map<Transaction>(createTransactionDto);

            await _unitOfWork.Transactions.AddAsync(transaction);

            var created = await _unitOfWork.SaveChangesAsyncWithResult();

            return created > 0;
        }

        public async Task<CreateTransactionRespDTO> CreateTransactionWithResultAsync(CreateTransactionReqDTO createTransactionDto)
        {
            var transaction = _mapper.Map<Transaction>(createTransactionDto);

            var processedTransaction = await TransactionProcessor(transaction);

            await _unitOfWork.Transactions.AddAsync(transaction);

            //validation if receiver/sender pair match transactiontype
            // if transactiontype is income => category sender(not account and no balance) , account receiver (account and has balance) etc.

            var created = await _unitOfWork.SaveChangesAsyncWithResult();

            if (created > 0)
            {
                var response = _mapper.Map<CreateTransactionRespDTO>(transaction);

                return response;
            }

            return new CreateTransactionRespDTO
            {
                ErrorMessage = new ErrorMessage
                {
                    StatusCode = 500,
                    Message = "Error occurred while creating Transaction."
                }
            };
        }

        public async Task<bool> DeleteTransactionAsync(Guid transactionId)
        {
            var transaction = await GetTransactionByIdAsync(transactionId);

            if (transaction == null)
            {
                return false;
            }

            _unitOfWork.Transactions.RemoveById(transactionId);

            var deleted = await _unitOfWork.SaveChangesAsyncWithResult();

            return deleted > 0;
        }

        public async Task<GetTransactionRespDto> GetAllTransactionsAsync()
        {
            var transactions = await _unitOfWork.Transactions.GetAll().OrderBy(x => x.Id).ToListAsync();

            if (transactions != null)
            {
                var response = new GetTransactionRespDto
                {
                    TransactionsRespDto = _mapper.Map<IEnumerable<GetTransactionRespDto.TransactionRespDto>>(transactions)
                };

                return response;
            }

            return new GetTransactionRespDto
            {
                ErrorMessage = new ErrorMessage
                {
                    StatusCode = 404,
                    Message = "Transactions not found."
                }
            };
        }

        public async Task<GetTransactionRespDto> GetTransactionByIdAsync(Guid transactionId)
        {
            var transaction = await _unitOfWork.Transactions.FindByCondition(x => x.Id.Equals(transactionId))
                .SingleOrDefaultAsync();

            var response = new GetTransactionRespDto();

            if (transaction != null)
            {
                var transactionDto = _mapper.Map<GetTransactionRespDto.TransactionRespDto>(transaction);
                response.TransactionsRespDto = new List<GetTransactionRespDto.TransactionRespDto> { transactionDto };
            }
            else
            {
                response.ErrorMessage = new ErrorMessage
                {
                    StatusCode = 404,
                    Message = "Transaction not found."
                };
            }

            return response;
        }

        public async Task<UpdateTransactionRespDTO> UpdateTransactionAsync(UpdateTransactionReqDTO transactionDto)
        {
            var transactionToUpdate = _mapper.Map<Transaction>(transactionDto);

            _unitOfWork.Transactions.Update(transactionToUpdate);

            var updated = await _unitOfWork.SaveChangesAsyncWithResult();

            if (updated > 0)
            {
                var updatedTransaction = _unitOfWork.Transactions.FindByCondition(x => x.Id == transactionDto.Id).SingleOrDefault();

                var response = _mapper.Map<UpdateTransactionRespDTO>(updatedTransaction);

                return response;
            }

            return new UpdateTransactionRespDTO
            {
                ErrorMessage = new ErrorMessage
                {
                    StatusCode = 500,
                    Message = "Error occurred while updating Transaction. Probably you haven't provided Transaction ID!"
                }
            };
        }
    }
}

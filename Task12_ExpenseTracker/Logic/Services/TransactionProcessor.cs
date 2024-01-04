using AutoMapper;
using DataAccess.Specifications.DebitAccountSpecs;
using Domain.RepoInterfaces;
using Domain.ValueObjects;
using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Responses.Create;
using Logic.ServiceInterfaces;
using System.Transactions;

namespace Logic.Services
{
    public class TransactionProcessor : ITransactionProcessor
    {
        private readonly IUnitOfWOrk _unitOfWork;
        private readonly ITransactionRepo _transactionRepo;
        private readonly IDebitAccountRepo _debitAccountRepo;
        private readonly IMapper _mapper;
        private readonly Validator _validator;

        public TransactionProcessor(IUnitOfWOrk unitOfWork, ITransactionRepo transactionRepo, IDebitAccountRepo debitAccountRepo, IMapper mapper, Validator validator)
        {
            _unitOfWork = unitOfWork;
            _transactionRepo = transactionRepo;
            _debitAccountRepo = debitAccountRepo;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateTransactionRespDTO> ProcessTransaction(CreateTransactionReqDTO createTransactionDto,
            CancellationToken cancellationToken)
        {
            CreateTransactionRespDTO? transProcessResultRespDto = new();

            switch (createTransactionDto.TransactionType)
            {
                case "Income":

                    transProcessResultRespDto = await ProcessIncomeTransaction(createTransactionDto, cancellationToken);

                    return transProcessResultRespDto;

                case "Expense":

                    transProcessResultRespDto = await ProcessExpenseTransaction(createTransactionDto, cancellationToken);

                    return transProcessResultRespDto;

                case "InternalTransfer":

                    transProcessResultRespDto = await ProcessInternalTransferTransaction(createTransactionDto, cancellationToken);

                    return transProcessResultRespDto;

                default:
                    transProcessResultRespDto.ErrorMessage = new ErrorMessage()
                    {
                        Message = "Wrong transaction type!",
                        StatusCode = 400
                    };

                    return transProcessResultRespDto;
            }
        }

        private async Task<CreateTransactionRespDTO> ProcessIncomeTransaction(CreateTransactionReqDTO createTransactionDto,
            CancellationToken cancellationToken)
        {
            CreateTransactionRespDTO? transProcessResultRespDto = new();

            var transactionValidationResult = await _validator.ValidateIncomeTransaction(createTransactionDto, cancellationToken);

            if (transactionValidationResult.ErrorMessage != null)
            {
                return transactionValidationResult;
            }

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var requiredReceiverDebitAcc = (await _debitAccountRepo.FindByConditionAsync(cancellationToken,
                    new DebitAccountGetByIdSpecification(x => x.Id == createTransactionDto.ReceiverId))).FirstOrDefault();

                if (requiredReceiverDebitAcc.StartCreditLimit == 0 && requiredReceiverDebitAcc.CurrentCreditLimit == 0 ||
                   requiredReceiverDebitAcc.StartCreditLimit == requiredReceiverDebitAcc.CurrentCreditLimit)
                {
                    requiredReceiverDebitAcc.Balance += createTransactionDto.Amount;
                }

                else
                {
                    double diff = createTransactionDto.Amount - (requiredReceiverDebitAcc.StartCreditLimit - requiredReceiverDebitAcc.CurrentCreditLimit);

                    if (diff <= 0)
                    {
                        requiredReceiverDebitAcc.CurrentCreditLimit += createTransactionDto.Amount;
                    }
                    else
                    {
                        requiredReceiverDebitAcc.CurrentCreditLimit = requiredReceiverDebitAcc.StartCreditLimit;
                        requiredReceiverDebitAcc.Balance += diff;
                    }
                }


                var mappedTransactionToAdd = _mapper.Map<Domain.Models.Transaction>(createTransactionDto);

                await _transactionRepo.AddAsync(mappedTransactionToAdd, cancellationToken);

                if ((await _unitOfWork.SaveChangesAsyncWithResult(cancellationToken)) == 0)
                {
                    transProcessResultRespDto.ErrorMessage = new ErrorMessage()
                    {
                        Message = "Transaction wasn't created!",
                        StatusCode = 400
                    };
                }

                transProcessResultRespDto.TransactionDto = _mapper.Map(mappedTransactionToAdd, transProcessResultRespDto.TransactionDto);

                scope.Complete();

                return transProcessResultRespDto;
            }
        }

        private async Task<CreateTransactionRespDTO> ProcessExpenseTransaction(CreateTransactionReqDTO createTransactionDto,
            CancellationToken cancellationToken)
        {
            CreateTransactionRespDTO? transProcessResultRespDto = new();

            var transactionValidationResult = await _validator.ValidateExpenseTransaction(createTransactionDto, cancellationToken);

            if (transactionValidationResult.ErrorMessage != null)
            {
                return transactionValidationResult;
            }

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var requiredExpenseAcc = (await _debitAccountRepo.FindByConditionAsync(cancellationToken,
                    new DebitAccountGetByIdSpecification(x => x.Id == createTransactionDto.SenderId))).FirstOrDefault();

                if (requiredExpenseAcc.Balance >= createTransactionDto.Amount)
                {
                    requiredExpenseAcc.Balance -= createTransactionDto.Amount;
                }
                else if (requiredExpenseAcc.Balance + requiredExpenseAcc.CurrentCreditLimit >= createTransactionDto.Amount)
                {
                    var remainingAmount = createTransactionDto.Amount - requiredExpenseAcc.Balance;
                    requiredExpenseAcc.Balance = 0;
                    requiredExpenseAcc.CurrentCreditLimit -= remainingAmount;
                }
                else
                {
                    transProcessResultRespDto.ErrorMessage = new ErrorMessage()
                    {
                        Message = "Expense amount is bigger than your balance account!",
                        StatusCode = 400
                    };

                    return transProcessResultRespDto;
                }

                var mappedTransactionToAdd = _mapper.Map<Domain.Models.Transaction>(createTransactionDto);

                await _transactionRepo.AddAsync(mappedTransactionToAdd, cancellationToken);

                if ((await _unitOfWork.SaveChangesAsyncWithResult(cancellationToken)) == 0)
                {
                    transProcessResultRespDto.ErrorMessage = new ErrorMessage()
                    {
                        Message = "Transaction wasn't created!",
                        StatusCode = 400
                    };
                }

                transProcessResultRespDto.TransactionDto = _mapper.Map(mappedTransactionToAdd, transProcessResultRespDto.TransactionDto);

                scope.Complete();

                return transProcessResultRespDto;
            }
        }

        private async Task<CreateTransactionRespDTO> ProcessInternalTransferTransaction(CreateTransactionReqDTO createTransactionDto,
            CancellationToken cancellationToken)
        {
            CreateTransactionRespDTO? transProcessResultRespDto = new();

            var transactionValidationResult = await _validator.ValidateInternalTransferTransaction(createTransactionDto, cancellationToken);

            if (transactionValidationResult.ErrorMessage != null)
            {
                return transactionValidationResult;
            }

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var requiredSenderDebitAcc = (await _debitAccountRepo
                    .FindByConditionAsync(cancellationToken, new DebitAccountGetByIdSpecification(x => x.Id == createTransactionDto.SenderId)))
                    .FirstOrDefault();

                var requiredReceiverDebitAcc = (await _debitAccountRepo
                    .FindByConditionAsync(cancellationToken, new DebitAccountGetByIdSpecification(x => x.Id == createTransactionDto.ReceiverId)))
                    .FirstOrDefault();

                requiredSenderDebitAcc.Balance -= createTransactionDto.Amount;
                requiredReceiverDebitAcc.Balance += createTransactionDto.Amount;

                var mappedTransactionToAdd = _mapper.Map<Domain.Models.Transaction>(createTransactionDto);

                await _transactionRepo.AddAsync(mappedTransactionToAdd, cancellationToken);

                if ((await _unitOfWork.SaveChangesAsyncWithResult(cancellationToken)) == 0)
                {
                    transProcessResultRespDto.ErrorMessage = new ErrorMessage()
                    {
                        Message = "Transaction wasn't created!",
                        StatusCode = 400
                    };
                }

                transProcessResultRespDto.TransactionDto = _mapper.Map(mappedTransactionToAdd, transProcessResultRespDto.TransactionDto);

                scope.Complete();

                return transProcessResultRespDto;
            }
        }
    }
}

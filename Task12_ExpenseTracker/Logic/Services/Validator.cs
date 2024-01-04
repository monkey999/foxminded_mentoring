using DataAccess.Specifications.AccountBaseSpecs;
using DataAccess.Specifications.CategorySpecs;
using DataAccess.Specifications.DebitAccountSpecs;
using DataAccess.Specifications.TransactionParticipant;
using Domain.RepoInterfaces;
using Domain.ValueObjects;
using Logic.DTO_Contracts.Requests.Create;
using Logic.DTO_Contracts.Responses.Create;

namespace Logic.Services
{
    public class Validator
    {
        private readonly IAccountBaseRepo _accountBaseRepo;
        private readonly ICategoryRepo _categoryRepo;
        private readonly IDebitAccountRepo _debitAccountRepo;
        private readonly ITransactionParticipantRepo _transactionParticipantRepo;
        private readonly List<ValidationResult?>? _validationProcessResult = new();
        private readonly CreateTransactionRespDTO _transProcessResultRespDto = new();

        public Validator(IAccountBaseRepo accountBaseRepo, ICategoryRepo categoryRepo, IDebitAccountRepo debitAccountRepo,
          ITransactionParticipantRepo transactionParticipantRepo)
        {
            _accountBaseRepo = accountBaseRepo;
            _categoryRepo = categoryRepo;
            _debitAccountRepo = debitAccountRepo;
            _transactionParticipantRepo = transactionParticipantRepo;
        }

        private void AddValidationError(string error)
        {
            _validationProcessResult.Add(new ValidationResult { Error = error });
        }

        public async Task<CreateTransactionRespDTO> ValidateExpenseTransaction(CreateTransactionReqDTO createTransactionDto, CancellationToken cancellationToken)
        {
            try
            {
                var sender = (await _accountBaseRepo
                    .FindByConditionAsync(cancellationToken, new AccountBaseGetByIdSpecification(x => x.Id == createTransactionDto.SenderId))).FirstOrDefault();

                if (sender is null)
                {
                    AddValidationError("Such sender account doesn't exist!");
                }

                var receiver = (await _categoryRepo
                    .FindByConditionAsync(cancellationToken, new CategoryGetByIdSpecification(x => x.Id == createTransactionDto.ReceiverId))).FirstOrDefault();

                if (receiver is null)
                {
                    AddValidationError("Such receiver category doesn't exist!");
                }

                if (_validationProcessResult.Any())
                {
                    string errorMessage = string.Join("\n", _validationProcessResult.Select(result => result?.Error));

                    _transProcessResultRespDto.ErrorMessage = new ErrorMessage()
                    {
                        Message = errorMessage,
                        StatusCode = 400
                    };

                    return _transProcessResultRespDto;
                }

                return _transProcessResultRespDto;
            }
            catch (Exception ex)
            {
                AddValidationError($"Occured unsupported validation error! {ex.Message}");

                string errorMessage = string.Join("\n", _validationProcessResult.Select(result => result?.Error));

                _transProcessResultRespDto.ErrorMessage = new ErrorMessage()
                {
                    Message = errorMessage,
                    StatusCode = 400
                };

                return _transProcessResultRespDto;
            }
        }

        public async Task<CreateTransactionRespDTO> ValidateIncomeTransaction(CreateTransactionReqDTO createTransactionDto, CancellationToken cancellationToken)
        {
            try
            {
                var sender = (await _transactionParticipantRepo
                    .FindByConditionAsync(cancellationToken, new TransactionParticipantGetByIdSpecification(x => x.Id == createTransactionDto.SenderId))).FirstOrDefault();

                if (sender is null)
                {
                    AddValidationError("Such sender category doesn't exist!");
                }

                var receiver = (await _transactionParticipantRepo
                    .FindByConditionAsync(cancellationToken, new TransactionParticipantGetByIdSpecification(x => x.Id == createTransactionDto.ReceiverId))).FirstOrDefault();

                if (receiver is null)
                {
                    AddValidationError("Such receiver account doesn't exist!");
                }

                if (_validationProcessResult.Any())
                {
                    string errorMessage = string.Join("\n", _validationProcessResult.Select(result => result?.Error));

                    _transProcessResultRespDto.ErrorMessage = new ErrorMessage()
                    {
                        Message = errorMessage,
                        StatusCode = 400
                    };

                    return _transProcessResultRespDto;
                }

                return _transProcessResultRespDto;
            }
            catch (Exception ex)
            {
                AddValidationError($"Occured unsupported validation error! {ex.Message}");

                string errorMessage = string.Join("\n", _validationProcessResult.Select(result => result?.Error));

                _transProcessResultRespDto.ErrorMessage = new ErrorMessage()
                {
                    Message = errorMessage,
                    StatusCode = 400
                };

                return _transProcessResultRespDto;
            }
        }

        public async Task<CreateTransactionRespDTO> ValidateInternalTransferTransaction(CreateTransactionReqDTO createTransactionDto, CancellationToken cancellationToken)
        {
            try
            {
                var sender = (await _debitAccountRepo
                   .FindByConditionAsync(cancellationToken, new DebitAccountGetByIdSpecification(x => x.Id == createTransactionDto.SenderId))).FirstOrDefault();

                if (sender is null)
                {
                    AddValidationError("Such sender debit account doesn't exist!");
                }

                var receiver = (await _debitAccountRepo
                    .FindByConditionAsync(cancellationToken, new DebitAccountGetByIdSpecification(x => x.Id == createTransactionDto.ReceiverId))).FirstOrDefault();

                if (receiver is null)
                {
                    AddValidationError("Such receiver debit account doesn't exist!");
                }

                if (!string.Equals(sender.CurrencyType.ToString(), receiver.CurrencyType.ToString()))
                {
                    AddValidationError("Currency types are not equal!");
                }

                if (_validationProcessResult.Any())
                {
                    string errorMessage = string.Join("\n", _validationProcessResult.Select(result => result?.Error));

                    _transProcessResultRespDto.ErrorMessage = new ErrorMessage()
                    {
                        Message = errorMessage,
                        StatusCode = 400
                    };

                    return _transProcessResultRespDto;
                }

                return _transProcessResultRespDto;
            }
            catch (Exception ex)
            {
                AddValidationError($"Occured unsupported validation error! {ex.Message}");

                string errorMessage = string.Join("\n", _validationProcessResult.Select(result => result?.Error));

                _transProcessResultRespDto.ErrorMessage = new ErrorMessage()
                {
                    Message = errorMessage,
                    StatusCode = 400
                };

                return _transProcessResultRespDto;
            }
        }
    }
}

using AutoMapper;
using DataAccess.Specifications.TransactionSpecs;
using Domain.Enums;
using Domain.RepoInterfaces;
using Logic.DTO_Contracts.Responses.Get;
using Logic.ServiceInterfaces;

namespace Logic.Services
{
    public class ReportService : IReportService
    {
        private readonly IMapper _mapper;
        private readonly ITransactionRepo _transactionRepo;
        private readonly IUnitOfWOrk _unitOfWork;

        public ReportService(IMapper mapper, ITransactionRepo transactionRepo, IUnitOfWOrk unitOfWork)
        {
            _mapper = mapper;
            _transactionRepo = transactionRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetDailyReportRespDTO> GetDailyReportAsync(DateTime selectedDate, CancellationToken cancellationToken)
        {
            double totalIncome = (await _transactionRepo
                .FindByConditionAsync(cancellationToken,
                    new TransactionGetAllSpecification(t => t.TransactionType == TransactionType.Income && t.Date.Date == selectedDate.Date)))
                        .Sum(t => t.Amount);

            double totalExpenses = (await _transactionRepo
                .FindByConditionAsync(cancellationToken,
                    new TransactionGetAllSpecification(t => t.TransactionType == TransactionType.Expense && t.Date.Date == selectedDate.Date)))
                        .Sum(t => t.Amount);

            var transactions = await _transactionRepo
                .FindByConditionAsync(cancellationToken, new TransactionGetAllSpecification(t => t.Date.Date == selectedDate.Date));

            var response = new GetDailyReportRespDTO
            {
                Date = selectedDate,
                TotalIncome = totalIncome,
                TotalExpenses = totalExpenses,
                TransactionsRespDto = _mapper.Map<IEnumerable<TransactionRespForGetDto>>(transactions)
            };

            return response;
        }

        public async Task<GetDatePeriodReportRespDTO> GetDatePeriodReportAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
        {
            double totalIncome = (await _transactionRepo
                .FindByConditionAsync(cancellationToken,
                    new TransactionGetAllSpecification(t => t.TransactionType == TransactionType.Income && t.Date >= startDate && t.Date <= endDate)))
                        .Sum(t => t.Amount);

            double totalExpenses = (await _transactionRepo
                .FindByConditionAsync(cancellationToken,
                    new TransactionGetAllSpecification(t => t.TransactionType == TransactionType.Expense && t.Date >= startDate && t.Date <= endDate)))
                        .Sum(t => t.Amount);

            var transactions = await _transactionRepo
                .FindByConditionAsync(cancellationToken, new TransactionGetAllSpecification(t => t.Date >= startDate && t.Date <= endDate));

            await _unitOfWork.SaveAsync(cancellationToken);

            var response = new GetDatePeriodReportRespDTO
            {
                StartDate = startDate,
                EndDate = endDate,
                TotalIncome = totalIncome,
                TotalExpenses = totalExpenses,
                TransactionsRespDto = _mapper.Map<IEnumerable<TransactionRespForGetDto>>(transactions)
            };

            return response;
        }
    }
}

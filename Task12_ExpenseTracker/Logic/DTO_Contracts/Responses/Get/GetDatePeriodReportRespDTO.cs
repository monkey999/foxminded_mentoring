using Domain.ValueObjects;

namespace Logic.DTO_Contracts.Responses.Get
{
    public class GetDatePeriodReportRespDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalIncome { get; set; }
        public double TotalExpenses { get; set; }
        public IEnumerable<TransactionRespForGetDto> TransactionsRespDto { get; set; }
        public ErrorMessage ErrorMessage { get; set; } = null;
    }
}

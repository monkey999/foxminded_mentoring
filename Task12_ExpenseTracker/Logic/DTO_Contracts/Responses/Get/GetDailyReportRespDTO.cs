using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Logic.DTO_Contracts.Responses.Get
{
    public class GetDailyReportRespDTO
    {
        public DateTime Date { get; set; }
        public double TotalIncome { get; set; }
        public double TotalExpenses { get; set; }

        public IEnumerable<TransactionRespForGetDto> TransactionsRespDto { get; set; }
        public ErrorMessage ErrorMessage { get; set; } = null;
    }
}

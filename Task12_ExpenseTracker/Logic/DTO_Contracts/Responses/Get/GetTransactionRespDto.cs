using Domain.Enums;
using Domain.ValueObjects;

namespace Logic.DTO_Contracts.Responses.Get
{
    public class GetTransactionRespDto
    {
        public IEnumerable<TransactionRespDto> TransactionsRespDto { get; set; }
        public ErrorMessage ErrorMessage { get; set; } = null;

        public class TransactionRespDto
        {
            public string TransactionType { get; set; }
            public double Amount { get; set; }
            public Guid SenderId { get; set; }
            public Guid ReceiverId { get; set; }
            public DateTime Date { get; set; }
        }
    }
}

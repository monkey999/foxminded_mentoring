using Domain.ValueObjects;

namespace Logic.DTO_Contracts.Responses.Get
{
    public class GetTransactionRespDto
    {
        public IEnumerable<TransactionRespForGetDto> TransactionsRespDto { get; set; }
        public ErrorMessage ErrorMessage { get; set; } = null;
    }
}

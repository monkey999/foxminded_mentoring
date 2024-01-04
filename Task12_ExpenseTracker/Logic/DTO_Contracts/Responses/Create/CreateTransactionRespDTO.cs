using Domain.ValueObjects;

namespace Logic.DTO_Contracts.Responses.Create
{
    public class CreateTransactionRespDTO
    {
        public TransactionRespForCreateDto TransactionDto { get; set; }
        public ErrorMessage? ErrorMessage { get; set; } = null;
    }
}

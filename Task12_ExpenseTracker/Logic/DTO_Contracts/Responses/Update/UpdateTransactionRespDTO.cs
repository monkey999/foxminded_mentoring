using Domain.Enums;
using Domain.ValueObjects;

namespace Logic.DTO_Contracts.Responses.Update
{
    public class UpdateTransactionRespDTO
    {
        public Guid Id { get; set; }
        public string TransactionType { get; set; }
        public double Amount { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public ErrorMessage ErrorMessage { get; set; } = null;
    }
}

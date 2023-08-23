using Domain.Enums;

namespace Logic.DTO_Contracts.Requests.Update
{
    public class UpdateTransactionReqDTO
    {
        public Guid Id { get; set; }
        public string TransactionType { get; set; }
        public double Amount { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
    }
}

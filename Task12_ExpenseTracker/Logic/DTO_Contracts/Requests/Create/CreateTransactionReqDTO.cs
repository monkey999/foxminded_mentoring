using Domain.Enums;

namespace Logic.DTO_Contracts.Requests.Create
{
    public class CreateTransactionReqDTO
    {
        public string TransactionType { get; set; }
        public double Amount { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}

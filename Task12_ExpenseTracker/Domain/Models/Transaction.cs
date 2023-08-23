using Domain.Enums;
using Domain.Models.BaseEntities;

namespace Domain.Models
{
    public class Transaction
    {
        public Transaction()
        {
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public TransactionType TransactionType { get; set; }
        public double Amount { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public TransactionParticipant From { get; set; }
        public TransactionParticipant To { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}

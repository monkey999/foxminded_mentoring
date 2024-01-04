using Domain.Enums;
using Domain.Models.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Transaction
    {
        public Transaction()
        {
        }

        public Guid Id { get; set; } 
        public TransactionType TransactionType { get; set; }
        public double Amount { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public TransactionParticipant From { get; set; }
        public TransactionParticipant To { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}

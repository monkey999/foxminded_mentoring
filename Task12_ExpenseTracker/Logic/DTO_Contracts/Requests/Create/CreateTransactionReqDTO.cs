using System.ComponentModel.DataAnnotations;

namespace Logic.DTO_Contracts.Requests.Create
{
    public class CreateTransactionReqDTO
    {
        [Required(ErrorMessage = $"TransactionType is required!")]
        public string TransactionType { get; set; }

        public double Amount { get; set; }

        [Required(ErrorMessage = "SenderId is required.")]
        public Guid SenderId { get; set; }

        [Required(ErrorMessage = "ReceiverId is required.")]
        public Guid ReceiverId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}

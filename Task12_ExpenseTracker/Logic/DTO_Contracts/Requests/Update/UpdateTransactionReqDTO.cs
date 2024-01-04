using System.ComponentModel.DataAnnotations;

namespace Logic.DTO_Contracts.Requests.Update
{
    public class UpdateTransactionReqDTO
    {
        [Required(ErrorMessage = $"ID is required!")]
        public Guid Id { get; set; }
        public string TransactionType { get; set; }
        public double Amount { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
    }
}

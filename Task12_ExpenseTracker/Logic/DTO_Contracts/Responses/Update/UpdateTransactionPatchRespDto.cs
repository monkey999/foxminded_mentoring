using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Logic.DTO_Contracts.Responses.Update
{
    public class UpdateTransactionPatchRespDto
    {
        public Guid Id { get; set; }
        public string TransactionType { get; set; }
        public double Amount { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public ErrorMessage ErrorMessage { get; set; } = null;

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}

using System.ComponentModel.DataAnnotations;

namespace Logic.DTO_Contracts.Responses.Get
{
    public class TransactionRespForGetDto
    {
        public Guid Id { get; set; }
        public string TransactionType { get; set; }
        public double Amount { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}

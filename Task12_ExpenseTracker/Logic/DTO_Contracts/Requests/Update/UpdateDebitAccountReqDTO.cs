using System.ComponentModel.DataAnnotations;

namespace Logic.DTO_Contracts.Requests.Update
{
    public class UpdateDebitAccountReqDTO
    {
        [Required(ErrorMessage = $"Id is required!")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Balance { get; set; }
    }
}

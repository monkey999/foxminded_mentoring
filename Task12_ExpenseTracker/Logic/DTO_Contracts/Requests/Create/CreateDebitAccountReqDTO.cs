using System.ComponentModel.DataAnnotations;

namespace Logic.DTO_Contracts.Requests.Create
{
    public class CreateDebitAccountReqDTO
    {
        [Required(ErrorMessage = $"Name is required!")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = $"Balance is required!")]
        public double Balance { get; set; }

        [Required(ErrorMessage = $"CurrencyType is required!")]
        public string CurrencyType { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Logic.DTO_Contracts.Requests.Create
{
    public class CreateCategoryReqDTO
    {
        [Required(ErrorMessage = $"CategoryName is required!")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = $"CategoryType is required!")]
        public string CategoryType { get; set; }
    }
}

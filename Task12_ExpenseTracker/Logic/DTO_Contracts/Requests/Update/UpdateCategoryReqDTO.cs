using Domain.Enums;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Logic.DTO_Contracts.Requests.Update
{
    public class UpdateCategoryReqDTO
    {
        [Required(ErrorMessage = "ID is required!")]
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
    }
}

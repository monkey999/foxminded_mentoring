using Domain.Enums;
using Domain.ValueObjects;

namespace Logic.DTO_Contracts.Responses.Update
{
    public class UpdateCategoryRespDTO
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryType { get; set; }
        public ErrorMessage ErrorMessage { get; set; } = null;
    }
}

using Domain.Enums;
using Domain.ValueObjects;

namespace Logic.DTO_Contracts.Responses.Create
{
    public class CreateCategoryRespDTO
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryType { get; set; }
        public ErrorMessage ErrorMessage { get; set; } = null;
    }
}

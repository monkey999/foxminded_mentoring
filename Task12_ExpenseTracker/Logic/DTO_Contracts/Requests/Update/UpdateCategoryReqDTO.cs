using Domain.Enums;

namespace Logic.DTO_Contracts.Requests.Update
{
    public class UpdateCategoryReqDTO
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryType { get; set; }
    }
}
